using Scraper.Core.Entities.ScrapingResults;

namespace Scraper.Core.Entities.Communication;

public class ScrapingContext
{
    public ScrapingContext()
    {
        Results = new List<ScrapingResult>();
    }

    public int Id { get; set; }
    public string Path { get; set; }
    public string LastScrapedUrl { get; set; }
    public IEnumerable<ScrapingResult> Results { get; set; }
}
