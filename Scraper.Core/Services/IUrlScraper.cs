using Scraper.Core.Entities.ScrapingResults;

namespace Scraper.Core.Services;

public interface IUrlScraper
{
    Task<IEnumerable<string>> TryScrapeDetailUrls(string url);
    Task<ScrapingResultList> TryScrapeMany(string url, string stopAtDetailUrl = null);
    Task<ScrapingResult> TryScrape(string url);
}
