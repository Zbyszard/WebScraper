using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using Scraper.Core.Interfaces.Requests;

namespace Scraper.Core.Services
{
    public class RequestService : IRequestService
    {
        private readonly IBrowsingContext _context;
        private readonly HttpClient _http;

        public RequestService(IConfiguration config, HttpClient http)
        {
            _context = BrowsingContext.New(config);
            _http = http;
        }

        public async Task<HttpResponseMessage> Get(string url)
        {
            return await _http.GetAsync(url);
             await _context.OpenAsync(url);
        }
    }
}
