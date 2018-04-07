using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RunConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("LogFile");

            log.Debug("Console Run Test...");
            Console.WriteLine("Console Run Test...");
            if (args.Length > 0)
            {
                string[] accgrpsList = args[0].Split(';');
                foreach (string accgrpsCode in accgrpsList)
                {
                    log.Debug(string.Format("Console Args : {0}", accgrpsCode));
                    Console.WriteLine(string.Format("Parameter Split AccessGroup : {0}",accgrpsCode));
                }
            }
            else
            {
                log.Debug(string.Format("Console Args is Not Use"));
                Console.WriteLine("Console Args is Not Use");
            }
            
            Console.WriteLine("Console Run Finish...");
            Console.ReadLine();
        }
    }
}
