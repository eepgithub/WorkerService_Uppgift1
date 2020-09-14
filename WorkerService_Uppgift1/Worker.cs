using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService_Uppgift1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        Random _random = new Random();


        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("The service has been started.");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("The service has been stopped.");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                int result = _random.Next(-20, 35);

                if (result > -15 && result < 30)

                    _logger.LogInformation($"The temp is {result}");


                else if (result < -15)
                    _logger.LogInformation($"WARNING, the temp is too low {result}");

                else if (result > 30)
                    _logger.LogInformation($"WARNING, the temp is too high {result}");



                await Task.Delay(60*1000, stoppingToken);
            }
        }
    }
}
