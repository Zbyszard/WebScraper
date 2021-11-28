using Scraper.Core.Entities.ScrapingResults;
using Scraper.Core.Services;

namespace Scraper.Base.Services;

public abstract class UrlScraper : IUrlScraper
{
    protected readonly IRequestService _requestService;
    protected readonly IScraper _scraper;

    public UrlScraper(IRequestService requestService, IScraper scraper)
    {
        _requestService = requestService;
        _scraper = scraper;
    }

    public virtual async Task<ScrapingResult> TryScrape(string url)
    {
        HttpResponseMessage response = await _requestService.Get(url);
        var result = await _scraper.TryGetSingleValue(response);
        result.BaseUrl = url;
        return result;
    }

    public abstract Task<IEnumerable<string>> TryScrapeDetailUrls(string url);
    public abstract Task<ScrapingResultList> TryScrapeMany(string url, string stopAtDetailUrl);
}
