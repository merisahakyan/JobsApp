using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace JobsApp.Infrastructure.Services
{
    public class UpdateJobsHostedService : BackgroundService
    {
        private readonly ILogger<UpdateJobsHostedService> _logger;

        public UpdateJobsHostedService(IServiceProvider services,
            ILogger<UpdateJobsHostedService> logger)
        {
            Services = services;
            _logger = logger;
        }

        public IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Consume Scoped Service Hosted Service running.");

            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Scoped Service Hosted Service is working.");

            var scope = Services.CreateScope();
            var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IUpdateJobsBackgroundTask>();

            await scopedProcessingService.UpdateCacheAsync(stoppingToken);

        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Consume Scoped Service Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
