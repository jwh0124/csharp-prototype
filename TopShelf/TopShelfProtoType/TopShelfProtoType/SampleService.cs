using System;
using System.Collections.Generic;
using System.Linq;
using Topshelf;
using System.Timers;
using System.Configuration;
using System.Threading.Tasks;
using System.Threading;

namespace TopShelfProtoType
{
    public class SampleService : ServiceControl
    {
        private readonly System.Timers.Timer _timer;
        //string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString;
        int delay = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Delay"));

        public SampleService()
        {
            this._timer = new System.Timers.Timer(1000);
            this._timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("hi");
        }

        public bool Start(HostControl hostControl)
        {
            this._timer.AutoReset = true;
            this._timer.Enabled = false;
            this._timer.Start();

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            this._timer.AutoReset = false;
            this._timer.Enabled = false;
            this._timer.Stop();

            return true;
        }
    }
}
