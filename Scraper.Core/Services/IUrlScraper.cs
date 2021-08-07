using Scraper.Core.Entities.ScrapingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Core.Services
{
    public interface IUrlScraper
    {
        Task<IEnumerable<string>> TryScrapeDetailUrls(string url);
        Task<ScrapingResultList> TryScrapeMany(string url, string stopAtDetailUrl = null);
        Task<ScrapingResult> TryScrape(string url);
    }
}
