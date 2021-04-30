using Scraper.Core.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Core.Entities
{
    public class FailedScrapingResult : ScrapingResult
    {
        public string ErrorMessage { get; init; }

        public FailedScrapingResult(int httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
