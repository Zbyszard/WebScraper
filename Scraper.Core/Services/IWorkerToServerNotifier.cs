using Scraper.Core.Entities.Communication;

namespace Scraper.Core.Services;

public interface IWorkerToServerNotifier
{
    Task NotifyServer(ScrapingContext context);
}
