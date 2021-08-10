using Scraper.Core.Entities.ScrapingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Core.Entities.Communication
{
    public class ScrapingContext
    {
        public ScrapingContext()
        {
            Results = new List<ScrapingResult>();
        }

        public int Id { get; set; }
        public string Path { get; set; }
        public string LastScrapedUrl { get; set; }
        public IEnumerable<ScrapingResult> Results { get; set; }
    }
}
