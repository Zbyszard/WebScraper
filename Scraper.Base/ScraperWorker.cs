using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Scraper.Core.Configuration;
using Scraper.Core.Entities.ScrapingResults;
using Scraper.Core.Services;
using Scraper.Core.Entities.Communication;

namespace Scraper.Base
{
    public abstract class ScraperWorker : BackgroundService
    {
        protected readonly ILogger<ScraperWorker> _logger;
        protected readonly IUrlScraper _scraper;
        protected readonly IWorkerToServerNotifier _notifier;
        protected readonly ScraperSettings _settings;

        public string WorkerName { get; init; }
        public List<ScrapingContext> ScrapingContexts { get; private set; }

        public ScraperWorker(ILogger<ScraperWorker> logger, IUrlScraper scraper, ScraperSettings settings,
            IWorkerToServerNotifier notifier)
        {
            _logger = logger;
            _scraper = scraper;
            _settings = settings;
            _notifier = notifier;
            WorkerName = nameof(ScraperWorker);
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation(WorkerName + " starting at: {time}", DateTimeOffset.UtcNow);
            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation(WorkerName + " stopping at: {time}", DateTimeOffset.UtcNow);
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
            foreach (var context in ScrapingContexts)
            {
                var results = await ScrapeContext(context);
                context.Results = results.Succesful;
            }

            await Task.WhenAll(ScrapingContexts.Select(c => NotifyServer(c)));
        }

        protected virtual async Task<ScrapingResultList> ScrapeContext(ScrapingContext context)
        {
            string url = $"{_settings.BaseUrl}/{context.Path}";
            ScrapingResultList results = await _scraper.TryScrapeMany(url, context.LastScrapedUrl);
            LogResults(results);
            return results;
        }

        protected void LogResults(ScrapingResultList results)
        {
            if (results.ErrorOccured)
                _logger.LogWarning(WorkerName + " failed scraping search results at {date}. Error message: {message}",
                    results.Date,
                    results.ErrorMessage);
            else if (results.List.Count() == 0)
                _logger.LogInformation(WorkerName + ": successful scrape at {date}. No data do gather",
                    results.Date);
            else
                _logger.LogWarning(WorkerName + ": successful scrape at {date}. Could not scrape {errorCount} urls",
                    results.Date,
                    results.Failures.Count());
            LogFailures(results.Failures);
        }

        protected void LogFailures(IEnumerable<FailedScrapingResult> failures)
        {
            foreach(var f in failures)
                _logger.LogWarning(WorkerName + " failed scraping at {date}. Error message: {message}",
                    f.ScrapeDate,
                    f.ErrorMessage);
        }
        
        protected virtual async Task NotifyServer(ScrapingContext context)
        {
            await _notifier.NotifyServer(context);
        }
    }
}
