using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Core.Entities.ScrapingResults
{
    public class ScrapingResultList
    {
        public IEnumerable<ScrapingResult> List { get; set; }
        public IEnumerable<ScrapingResult> Succesful 
        {
            get => List?.Where(r => r is not FailedScrapingResult); 
        }
        public IEnumerable<FailedScrapingResult> Failures 
        { 
            get => List?.Select(r => r as FailedScrapingResult)
                .Where(r => r is not null);
        }
        public string ErrorMessage { get; set; }
        public bool ErrorOccured { get => !string.IsNullOrEmpty(ErrorMessage); }
        public DateTimeOffset Date { get; set; }

        public ScrapingResultList()
        {
            List = new List<ScrapingResult>();
            Date = DateTimeOffset.UtcNow;
        }
    }
}
