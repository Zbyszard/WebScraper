using System.Collections;
using System.Net;

namespace Scraper.Core.Entities.ScrapingResults;

public class ScrapingResultList : IList<ScrapingResult>
{
    public IList<ScrapingResult> List { get; set; }
    public IEnumerable<ScrapingResult> Succesful
    {
        get => List?.Where(r => r is not FailedScrapingResult);
    }
    public IEnumerable<FailedScrapingResult> Failures
    {
        get => List?.Select(r => r as FailedScrapingResult)
            .Where(r => r is not null);
    }
    public string ErrorMessage { get; set; }
    public bool ErrorOccured { get => !string.IsNullOrEmpty(ErrorMessage); }
    public HttpStatusCode Status { get; set; }
    public DateTimeOffset Date { get; set; }

    public int Count => List.Count;

    public bool IsReadOnly => List.IsReadOnly;

    public ScrapingResult this[int index]
    {
        get => List[index];
        set => List[index] = value;
    }

    public ScrapingResultList()
    {
        List = new List<ScrapingResult>();
        Date = DateTimeOffset.UtcNow;
        ErrorMessage = string.Empty;
    }

    public IEnumerator<ScrapingResult> GetEnumerator() => List.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public int IndexOf(ScrapingResult item) => List.IndexOf(item);

    public void Insert(int index, ScrapingResult item)
    {
        List.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        List.RemoveAt(index);
    }

    public void Add(ScrapingResult item)
    {
        List.Add(item);
    }

    public void Clear()
    {
        List.Clear();
    }

    public bool Contains(ScrapingResult item) => List.Contains(item);

    public void CopyTo(ScrapingResult[] array, int arrayIndex)
    {
        List.CopyTo(array, arrayIndex);
    }

    public bool Remove(ScrapingResult item) => List.Remove(item);
}
