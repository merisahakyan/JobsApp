using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JobsApp.Core.Interfaces;
using JobsApp.Core.Models;
using JobsApp.Core.StaticData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace JobsApp.Infrastructure.Services
{
    public interface IUpdateJobsBackgroundTask
    {
        Task UpdateCacheAsync(CancellationToken stoppingToken);
        Task StopAsync(CancellationToken stoppingToken);
    }
    public class UpdateJobsBackgroundTask : IUpdateJobsBackgroundTask, IDisposable
    {
        private readonly IMemoryCache _cache;
        private readonly IRepositoryManager _repoManager;
        private readonly ILogger<UpdateJobsBackgroundTask> _logger;
        private Timer _timer;

        public UpdateJobsBackgroundTask(ILogger<UpdateJobsBackgroundTask> logger,
            IMemoryCache cache,
            IRepositoryManager repoManager)
        {
            _logger = logger;
            _repoManager = repoManager;
            _cache = cache;
        }

        public Task UpdateCacheAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(async o => UpdateCacheAsync(o), null, TimeSpan.Zero,
                TimeSpan.FromHours(1));

            return Task.CompletedTask;
        }

        private async Task UpdateCacheAsync(object state)
        {
            _cache.Remove(CacheKeys.JOBS);

            var newData = await _repoManager.Jobs.GetAll().ToListAsync();
            _cache.Set(CacheKeys.JOBS, newData);

            _logger.LogInformation(
                "Timed Hosted Service is working.Cache updated");
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
