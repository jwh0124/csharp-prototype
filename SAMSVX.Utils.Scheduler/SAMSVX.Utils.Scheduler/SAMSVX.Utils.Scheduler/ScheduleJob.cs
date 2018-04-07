using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SAMSVX.Utils.Scheduler
{
    public class ScheduleJob
    {
        readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ScheduleJob));

        Timer timer;
        IJob job;

        Thread thread;
        bool isLoop = true;

        string name = "ScheduleJob";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        List<TimeSpan> reservationTime;
        public List<TimeSpan> ReservationTime
        {
            get { return reservationTime; }
            set { reservationTime = value; }
        }

        public ScheduleJob(IJob job)
        {
            reservationTime = new List<TimeSpan>() { new TimeSpan() };
            this.job = job;
        }
        public ScheduleJob(string name, List<TimeSpan> reservationTime, IJob job)
        {
            this.name = name;
            this.reservationTime = reservationTime;
            this.job = job;
        }

        public void Start()
        {
            thread = new Thread(new ThreadStart(ScheduledJobStart));
            thread.Start();
        }

        public void Stop()
        {
            isLoop = false;
            timer.Dispose();
            thread.Abort();
        }

        public void ScheduledJobStart()
        {
            AutoResetEvent autoEvent = new AutoResetEvent(false);

            TimerCallback tcb = new TimerCallback(ExecuteJob);

            TimeSpan dueTime = GetDueTime();

            timer = new Timer(tcb, autoEvent, (long)dueTime.TotalMilliseconds, Timeout.Infinite);

            log.Debug(string.Format("[{0}] Timer is Started. Next Interval : {1}", name, dueTime.TotalMilliseconds));

            while (isLoop)
            {
                autoEvent.WaitOne();

                Thread.Sleep(1000);

                dueTime = GetDueTime();
                timer.Change((long)dueTime.TotalMilliseconds, Timeout.Infinite);

                log.Debug(string.Format("[{0}] Timer is Changed. Next Interval : {1}", name, dueTime.TotalMilliseconds));
            }
        }

        private TimeSpan GetDueTime()
        {
            TimeSpan dueTime = new TimeSpan();

            DateTime now = DateTime.Now;
            TimeSpan currentTime = new TimeSpan(now.Hour, now.Minute, now.Second);

            reservationTime.Sort();
            for (int i = 0; i < reservationTime.Count; i++)
            {
                if (reservationTime[i].CompareTo(currentTime) < 0)
                { // 예약시간이 현재시간 이전
                    if (i < reservationTime.Count - 1)
                    { // 다음 예약 시간이 있음
                        continue;
                    }
                    else
                    { // 다음 예약 시간이 없음
                        DateTime reservationDate = new DateTime(now.Year, now.Month, now.Day, reservationTime[i].Hours, reservationTime[i].Minutes, reservationTime[i].Seconds);
                        reservationDate = reservationDate.AddDays(1);
                        dueTime = reservationDate.Subtract(now);
                    }
                }
                else
                { // 예약시간이 현재시간 이후
                    dueTime = reservationTime[i].Subtract(new TimeSpan(now.Hour, now.Minute, now.Second));
                    break;
                }
            }

            return dueTime;
        }

        private void ExecuteJob(Object state)
        {
            AutoResetEvent autoResetEvent = (AutoResetEvent)state;

            try
            {
                job.Execute();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("[{0}] {1}", name, ex.Message));
            }

            autoResetEvent.Set();
        }
    }
}
