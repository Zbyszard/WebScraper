using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;

namespace Scraper.Core.Configuration
{
    public static class ScraperDefaults
    {
        private const int DefaultInterval = 10 * 1000;

        public static IConfiguration Configuration { get; private set; }
        public static ScraperSettings Settings { get; private set; }

        static ScraperDefaults()
        {
            Configuration = AngleSharp.Configuration
                .Default
                .WithDefaultLoader();

            Settings = new() { ScrapingInterval = DefaultInterval };
        }
    }
}
