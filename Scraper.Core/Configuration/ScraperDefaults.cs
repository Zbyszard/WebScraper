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
        public static IConfiguration Configuration { get; private set; }
        public static IBrowsingContext Context { get; set; }
        public static ScraperSettings Settings { get; private set; }

        static ScraperDefaults()
        {
            Configuration = AngleSharp.Configuration
                .Default
                .WithDefaultLoader();

            Context = BrowsingContext.New(Configuration);
        }
    }
}
