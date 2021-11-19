using Scraper.Core.Configuration;
using Scraper.Core.Services;

namespace Scraper.Base.Services;

public class RequestService : IRequestService
{
    private readonly HttpClient _http;

    public RequestService(ScraperSettings settings, IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient(settings.HttpClientName);
    }

    public async Task<HttpResponseMessage> Get(string url)
    {
        return await _http.GetAsync(url);
    }
}
