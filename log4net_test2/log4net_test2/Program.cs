using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace log4net_test2
{
    class Program
    {
        private static ILog log = LogManager.GetLogger("System");
        private static ILog log2 = LogManager.GetLogger("EventHist");
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            log.Info("1111");
            log2.Info("2222");
        }
    }
}
