using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgroundServiceDemo
{
    public class DerivedBackgroundPrinter : BackgroundService
    {
        private readonly ILogger<DerivedBackgroundPrinter> _logger;
        private readonly IWorker _worker;

        public DerivedBackgroundPrinter(ILogger<DerivedBackgroundPrinter> logger, IWorker worker)
        {
            _worker = worker;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _worker.DoWork(stoppingToken);
        }
    }
}
