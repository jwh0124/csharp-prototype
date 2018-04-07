using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Topshelf;

namespace TopShelfProtoType
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                HostFactory.Run(hc => // Window Application Start
                                    {
                                        hc.Service<SampleService>(sc => // Window Application Service Call
                                                                    {
                                                                        sc.ConstructUsing(() => new SampleService()); // Create Instance SampleService 
                                                                        sc.WhenStarted((s,c) => s.Start(c)); // Start() Method Start
                                                                        sc.WhenStopped((s,c) => s.Stop(c)); // Stop() Method Start
                                                                    });

                                        hc.RunAsLocalSystem();
                                        hc.SetDisplayName("Topshelf Windows Service"); // Window Service Naming
                                        hc.SetDescription("Windows Service with Topshelf"); // Window Service Comment
                                        hc.SetServiceName("TopshelfWindowsService"); // Window Service Panel Naming
                                        hc.StartAutomatically(); // Window Service Install and Auto Start
                                    }
                                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
