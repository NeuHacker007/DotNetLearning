using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BackgroundServiceDemo
{
    public class Worker : IWorker
    {
        private readonly ILogger<Worker> _logger;
        private int number = 0;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        public async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Interlocked.Increment(ref number);
                _logger.LogInformation($"Worker printing num: {number}");

                await Task.Delay(5000);
            }
        }
    }
}
