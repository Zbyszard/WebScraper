using Scraper.Core.Abstractions.Entities;
using Scraper.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Core.Interfaces.Scraping
{
    public interface IDomScraper
    {
        Task<ScrapingResult> TryGetNewValue(HttpResponseMessage response);
        protected static bool CheckRequestStatus(HttpResponseMessage response, out FailedScrapingResult result, out int responseStatus)
        {
            responseStatus = (int)response.StatusCode;
            if (responseStatus < 200 || responseStatus >= 300)
            {
                result = new FailedScrapingResult(responseStatus) 
                { 
                    HttpStatusCode = responseStatus,
                    ErrorMessage = $"HTTP request returned status { responseStatus }"
                };
                return false;
            }
            result = null;
            return true;
        }
    }
}
