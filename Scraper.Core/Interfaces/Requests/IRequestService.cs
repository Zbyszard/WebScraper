using System.Net.Http;
using System.Threading.Tasks;

namespace Scraper.Core.Interfaces.Requests
{
    public interface IRequestService
    {
        Task<HttpResponseMessage> Get(string url);
    }
}