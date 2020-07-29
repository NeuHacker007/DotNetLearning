using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgroundServiceDemo
{
    public class BackgroundPrinter : IHostedService, IDisposable
    {
        private readonly ILogger<BackgroundPrinter> _logger;
        private int _number = 0;

        private Timer timer;

        public BackgroundPrinter(ILogger<BackgroundPrinter> logger)
        {
            this._logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(t =>
            {
                Interlocked.Increment(ref _number);
                _logger.LogInformation($"Printing from worker number: {_number}");
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Printing worker is stopped");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
