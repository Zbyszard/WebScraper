using Scraper.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Core.Services
{
    public interface IUrlScraper
    {
        Task<ScrapingResult> TryScrape(string url);
    }
}
