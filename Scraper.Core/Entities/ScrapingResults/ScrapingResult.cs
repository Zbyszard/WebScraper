using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scraper.Core.Entities.ScrapingResults
{
    public abstract class ScrapingResult
    {
        public ScrapingResult()
        {
            ScrapeDate = DateTimeOffset.UtcNow;
        }
        public DateTimeOffset ScrapeDate { get; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Path { get; set; }
        public string BaseUrl { get; set; }
        public string Link { get => $"{BaseUrl}/{Path}".Replace("//", "/"); }
    }
}
