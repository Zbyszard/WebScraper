using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Dom;
using Scraper.Core.Configuration;
using Scraper.Core.Services;

namespace Scraper.Core.Services
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _http;

        public RequestService(ScraperSettings settings, IHttpClientFactory httpClientFactory)
        {

            _http = httpClientFactory.CreateClient(settings.ClientName);
        }

        public async Task<HttpResponseMessage> Get(string url)
        {
            return await _http.GetAsync(url);
        }
    }
}
