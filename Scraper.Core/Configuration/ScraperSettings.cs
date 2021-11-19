namespace Scraper.Core.Configuration;

public class ScraperSettings
{
    public const string SettingName = "Scraping";
    public int ScrapingInterval { get; set; }
    public string BaseUrl { get; set; }
    public string HttpClientName { get; set; }
}

