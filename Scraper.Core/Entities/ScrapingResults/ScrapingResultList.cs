using System.Collections;
using System.Net;

namespace Scraper.Core.Entities.ScrapingResults;

public class ScrapingResultList : IEnumerable<ScrapingResult>
{
    public IEnumerable<ScrapingResult> List { get; set; }
    public IEnumerable<ScrapingResult> Succesful
    {
        get => List?.Where(r => r is not FailedScrapingResult);
    }
    public IEnumerable<FailedScrapingResult> Failures
    {
        get => List?.Select(r => r as FailedScrapingResult)
            .Where(r => r is not null);
    }
    public string ErrorMessage { get; set; }
    public bool ErrorOccured { get => !string.IsNullOrEmpty(ErrorMessage); }
    public HttpStatusCode Status { get; set; }
    public DateTimeOffset Date { get; set; }

    public ScrapingResultList()
    {
        List = new List<ScrapingResult>();
        Date = DateTimeOffset.UtcNow;
    }

    public IEnumerator<ScrapingResult> GetEnumerator() => List.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
