using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Core.Entities.ScrapingResults
{
    public class FailedScrapingResult : ScrapingResult
    {
        public string ErrorMessage { get; init; }
    }
}
