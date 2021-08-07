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
    public class UrlScraper : IUrlScraper
    {
        private readonly IRequestService _requestService;
        private readonly IDomScraper _domScraper;

        public UrlScraper(IRequestService requestService, IDomScraper domScraper)
        {
            _requestService = requestService;
            _domScraper = domScraper;
        }

        public virtual async Task<ScrapingResult> TryScrape(string url)
        {
            HttpResponseMessage response = await _requestService.Get(url);
            return await _domScraper.TryGetNewValue(response);
        }
    }
}
