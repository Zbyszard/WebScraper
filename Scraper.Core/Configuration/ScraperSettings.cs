using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Core.Configuration
{
    public struct ScraperSettings
    {
        public int ScrapingInterval { get; set; }
        public string Url { get; set; }
    }
}
