using System.Net;

namespace Scraper.Core.Entities.ScrapingResults;

public abstract class ScrapingResult
{
    public ScrapingResult()
    {
        ScrapeDate = DateTimeOffset.UtcNow;
    }
    public DateTimeOffset ScrapeDate { get; }
    public HttpStatusCode HttpStatusCode { get; set; }
    public string Path { get; set; }
    public string BaseUrl { get; set; }
    public string Link { get => $"{BaseUrl}/{Path}".Replace("//", "/"); }
}
