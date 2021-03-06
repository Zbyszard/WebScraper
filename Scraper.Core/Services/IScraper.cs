using Scraper.Core.Entities.ScrapingResults;
using System.Net;

namespace Scraper.Core.Services;

public interface IScraper
{
    Task<IEnumerable<string>> TryGetDetailStrings(HttpResponseMessage response);
    Task<ScrapingResult> TryGetSingleValue(HttpResponseMessage response);
    Task<ScrapingResultList> TryGetManyValues(HttpResponseMessage responseMessage);
    protected static bool CheckRequestStatus(HttpResponseMessage response, out FailedScrapingResult result, out HttpStatusCode responseStatus)
    {
        responseStatus = response.StatusCode;
        result = null;
        if (response.IsSuccessStatusCode)
            return true;

        result = new FailedScrapingResult
        {
            HttpStatusCode = response.StatusCode,
            ErrorMessage = $"HTTP request returned status { (int)responseStatus }"
        };
        return false;
    }
}
