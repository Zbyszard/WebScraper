﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Core.Configuration
{
    public class ScraperSettings
    {
        public const string SettingName = "Scraping";
        public int ScrapingInterval { get; set; }
        public string Url { get; set; }
        public string MainPage { get; set; }
        public string ClientName { get; set; }
    }
}
