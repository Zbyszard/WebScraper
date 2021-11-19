using Scraper.Core.Entities.ScrapingResults;
using Scraper.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Base.Services
{
    public abstract class UrlScraper : IUrlScraper
    {
        private readonly IRequestService _requestService;
        private readonly IScraper _scraper;

        public UrlScraper(IRequestService requestService, IScraper scraper)
        {
            _requestService = requestService;
            _scraper = scraper;
        }

        public virtual async Task<ScrapingResult> TryScrape(string url)
        {
            HttpResponseMessage response = await _requestService.Get(url);
            var result = await _scraper.TryGetNewValue(response);
            result.BaseUrl = url;
            return result;
        }

        public abstract Task<IEnumerable<string>> TryScrapeDetailUrls(string url);
        public abstract Task<ScrapingResultList> TryScrapeMany(string url, string stopAtDetailUrl);
    }
}
