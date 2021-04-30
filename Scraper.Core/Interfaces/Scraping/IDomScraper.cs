using Scraper.Core.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Core.Interfaces.Scraping
{
    public interface IDomScraper
    {
        Task<ScrapingResult> TryGetNewValue(string domSource);
    }
}
