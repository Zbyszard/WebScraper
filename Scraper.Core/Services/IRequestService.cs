using System.Net.Http;
using System.Threading.Tasks;

namespace Scraper.Core.Services
{
    public interface IRequestService
    {
        Task<HttpResponseMessage> Get(string url);
    }
}