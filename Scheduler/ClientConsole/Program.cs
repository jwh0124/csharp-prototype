using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAMSVX.Utils.Scheduler;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan reservationTime1 = new TimeSpan(11, 56, 0);
            TimeSpan reservationTime2 = new TimeSpan(11, 57, 0);
            TimeSpan reservationTime3 = new TimeSpan(11, 58, 0);
            TimeSpan reservationTime4 = new TimeSpan(11, 59, 0);

            IJob simpleJob = new SimpleJob();
            ScheduleJob scheduleJob = new ScheduleJob(simpleJob);
            scheduleJob.ReservationTime = new List<TimeSpan>() { reservationTime1, reservationTime2, reservationTime3, reservationTime4 };
            scheduleJob.Start();

            Console.ReadLine();
            scheduleJob.Stop();
        }
    }

    public class SimpleJob : IJob
    {
        public void Execute()
        {
            Console.WriteLine("Simple Job is Execute.");
        }
    }
}
