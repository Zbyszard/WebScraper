using Scraper.Core.Services;

namespace Scraper.Base.Services;

public class RequestService : IRequestService
{
    private readonly HttpClient _http;

    public RequestService(HttpClient httpClient)
    {
        _http = httpClient;
    }

    public async Task<HttpResponseMessage> Get(string url)
    {
        return await _http.GetAsync(url);
    }
}
