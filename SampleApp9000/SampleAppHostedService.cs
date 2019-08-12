using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SampleApp9000
{
    public class SampleAppHostedService : IHostedService
    {
        private readonly ILogger<SampleAppHostedService> _logger;

        public SampleAppHostedService(ILogger<SampleAppHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Hello AwsCloudWatch!");

            return
                Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return
                Task.CompletedTask;
        }
    }
}
