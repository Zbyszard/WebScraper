using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Scraper.Core.Abstractions.Entities;
using Scraper.Core.Configuration;
using Scraper.Core.Entities;
using Scraper.Core.Interfaces.Controllers;
using Scraper.Core.Interfaces.Scraping;

namespace Scraper.Core.Abstractions.Workers
{
    //public abstract class ScraperWorkerBase<T> : BackgroundService where T : BackgroundService
    public abstract class ScraperWorker : BackgroundService
    {
        protected readonly ILogger<ScraperWorker> _logger;
        protected readonly IUrlScraper _scraper;
        protected readonly ScraperSettings _settings;

        public string WorkerName { get; init; } = "Worker";

        public ScraperWorker(ILogger<ScraperWorker> logger, IUrlScraper scraper, ScraperSettings settings)
        {
            _logger = logger;
            _scraper = scraper;
            _settings = settings;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation(WorkerName + " starting at: {time}", DateTimeOffset.Now);
            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation(WorkerName + " stopping at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Work();
                await Task.Delay(_settings.ScrapingInterval, cancellationToken);
            }
        }

        protected virtual async Task Work()
        {
            await _scraper.TryScrape(_settings.Url);
        }
    }
}
