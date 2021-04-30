using Scraper.Core.Abstractions.Entities;
using Scraper.Core.Entities;
using Scraper.Core.Interfaces.Controllers;
using Scraper.Core.Interfaces.Requests;
using Scraper.Core.Interfaces.Scraping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Core.Abstractions.Controllers
{
    public abstract class UrlScraperBase : IUrlScraper
    {
        private readonly IRequestService _requestService;
        private readonly IDomScraper _domScraper;

        public UrlScraperBase(IRequestService requestService, IDomScraper domScraper)
        {
            _requestService = requestService;
            _domScraper = domScraper;
        }

        public virtual async Task<ScrapingResult> TryScrape(string url)
        {
            HttpResponseMessage response = await _requestService.Get(url);

            int status = (int) response.StatusCode;
            if (status >= 200 && status < 300)
                return new FailedScrapingResult(status) { ErrorMessage = $"Http request returned status { status }" };

            string responseContent = await response.Content.ReadAsStringAsync();
            return await _domScraper.TryGetNewValue(responseContent);
        }
    }
}
