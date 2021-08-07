﻿using Scraper.Core.Entities.ScrapingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Core.Services
{
    public interface IDomScraper
    {
        Task<ScrapingResult> TryGetNewValue(HttpResponseMessage response);
        protected static bool CheckRequestStatus(HttpResponseMessage response, out FailedScrapingResult result, out int responseStatus)
        {
            responseStatus = (int)response.StatusCode;
            if (!response.IsSuccessStatusCode)
            {
                result = new FailedScrapingResult 
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
