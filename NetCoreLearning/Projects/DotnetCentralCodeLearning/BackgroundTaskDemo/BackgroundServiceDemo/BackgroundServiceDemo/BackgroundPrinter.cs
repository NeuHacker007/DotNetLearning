
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgroundServiceDemo
{
    public class BackgroundPrinter : IHostedService
    {
        private readonly ILogger<BackgroundPrinter> _logger;
        private readonly IWorker _worker;

        public BackgroundPrinter(ILogger<BackgroundPrinter> logger, IWorker worker)
        {
            _worker = worker;
            this._logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _worker.DoWork(cancellationToken);

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Printing worker is stopped");
            return Task.CompletedTask;
        }
    }
}
