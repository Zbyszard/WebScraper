using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Scraper.Core.Configuration;
using Scraper.Core.Entities;
using Scraper.Core.Services;

namespace Scraper.Base
{
    public abstract class ScraperWorker : BackgroundService
    {
        protected readonly ILogger<ScraperWorker> _logger;
        protected readonly IUrlScraper _scraper;
        protected readonly ScraperSettings _settings;

        public string WorkerName { get; init; }

        public ScraperWorker(ILogger<ScraperWorker> logger, IUrlScraper scraper, ScraperSettings settings)
        {
            _logger = logger;
            _scraper = scraper;
            _settings = settings;
            WorkerName = nameof(ScraperWorker);
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
                ScrapingResult result = await Work();
                await Task.Delay(_settings.ScrapingInterval, cancellationToken);
            }
        }

        protected virtual async Task<ScrapingResult> Work()
        {
            ScrapingResult result = await _scraper.TryScrape(_settings.MainPage);
            if (result is FailedScrapingResult fail)
                _logger.LogWarning(WorkerName + " failed scraping at {date}. Error message: {message}",
                    fail.ScrapeDate,
                    fail.ErrorMessage);
            else
                _logger.LogInformation(WorkerName + ": successful scrape at {date}", result.ScrapeDate);
            return result;
        }

        protected virtual async Task NotifyClients(ScrapingResult result)
        {
            await Task.CompletedTask;
        }
    }
}
