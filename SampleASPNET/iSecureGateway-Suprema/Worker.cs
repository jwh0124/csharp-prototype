using iSecureGateway_Suprema.Commons.Config;
using Microsoft.Extensions.Options;

namespace iSecureGateway_Suprema
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly ApplicationSettings applicationSettings;

        public Worker(ILogger<Worker> logger, IOptions<ApplicationSettings> options)
        {
            this.logger = logger;
            applicationSettings = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.CompletedTask;
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            await base.StopAsync(stoppingToken);
        }
    }
}
