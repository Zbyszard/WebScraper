namespace Scraper.Core.Services;

public interface IRequestService
{
    Task<HttpResponseMessage> Get(string url);
}
