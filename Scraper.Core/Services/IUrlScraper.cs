using Scraper.Core.Entities.ScrapingResults;

namespace Scraper.Core.Services;

public interface IUrlScraper
{
    /// <summary>
    /// Analyzes provided url in search of detail urls.
    /// </summary>
    /// <param name="url">Url to a resource that must contain urls to searched details.</param>
    /// <returns>Urls to resources that contain detailed information about scraped objects.</returns>
    Task<IEnumerable<string>> TryScrapeDetailUrls(string url);
    Task<ScrapingResultList> TryScrapeMany(string url, string stopAtDetailUrl = null);
    Task<ScrapingResult> TryScrape(string url);
}
