namespace Scraper.Core.Entities.ScrapingResults;

public class FailedScrapingResult : ScrapingResult
{
    public string ErrorMessage { get; init; }
}
