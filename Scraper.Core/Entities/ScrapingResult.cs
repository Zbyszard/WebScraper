using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Core.Entities
{
    public abstract class ScrapingResult
    {
        public ScrapingResult()
        {
            ScrapeDate = DateTimeOffset.UtcNow;
        }
        public DateTimeOffset ScrapeDate { get; }
        public int HttpStatusCode { get; set; }
    }
}
