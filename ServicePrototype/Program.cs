using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServicePrototype.Common;
using System.Data.Entity;

namespace ServicePrototype
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Database.SetInitializer<PrototypeContext>(new DatabaseInitializer());
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSystemd()
                .ConfigureServices((hostContext, services) =>
                {
                    
                    services.AddHostedService<Worker>();
                });
    }
}
