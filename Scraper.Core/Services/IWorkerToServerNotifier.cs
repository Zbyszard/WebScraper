using Scraper.Core.Entities.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Core.Services
{
    public interface IWorkerToServerNotifier
    {
        Task NotifyServer(ScrapingContext context);
    }
}
