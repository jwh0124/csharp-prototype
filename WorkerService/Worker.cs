using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ServicePrototype
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient httpClient;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            httpClient = new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            httpClient.Dispose();
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            /*while (!stoppingToken.IsCancellationRequested)
            {
                var result = await httpClient.GetAsync("https://www.google.com");

                if (result.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Worker running at: {time}, Status Code {StatusCode}", DateTimeOffset.Now, result.StatusCode);
                }
                else
                {
                    _logger.LogError("{StatusCode}", result.StatusCode);
                }

                await Task.Delay(5000, stoppingToken);
            }*/

            using (var userDb = new PrototypeContext())
            {
                var user = userDb.Users.ToList();
                Console.WriteLine("ID : {0}, Name: {1}", user.First().id, user.First().name);
            }

            await Task.Delay(5000, stoppingToken);
        }
    }
}
