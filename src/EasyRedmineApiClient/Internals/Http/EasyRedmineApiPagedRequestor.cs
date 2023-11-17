using System.Net.Http.Headers;

namespace EasyRedmineApiClient.Internals.Http;

internal sealed class EasyRedmineApiPagedRequestor
{
    private const int MaxItemsPerPage = 100;

    private readonly EasyRedmineApiRequestor _requestor;

    public EasyRedmineApiPagedRequestor(EasyRedmineApiRequestor requestor)
        => _requestor = requestor;

    private static string GetPagedUrl(string url, int pageNumber)
    {
        string parameterSymbol = url.Contains("?") ? "&" : "?";
        return $"{url}{parameterSymbol}limit={MaxItemsPerPage}&page={pageNumber}";
    }
    private static List<string> GetPagedUrls(string originalUrl, int totalPages)
    {
        var pagedUrls = new List<string>();
    
        for (int i = 2; i <= totalPages; i++)
            pagedUrls.Add(GetPagedUrl(originalUrl, i));
    
        return pagedUrls;
    }
    private async Task<IList<T>> GetTotalPagedList<T>(string url, int totalPages, List<T> result)
    {
        //get paged urls
        var pagedUrls = GetPagedUrls(url, totalPages);
        if (pagedUrls.Count == 0)
            return result;

        int partitionSize = Environment.ProcessorCount;
        var remainingUrls = pagedUrls;
        do
        {
            var responses = remainingUrls.Take(partitionSize).Select(
                async u => await _requestor.GetPage<T>(u));

            var results = await Task.WhenAll(responses);
            result.AddRange(results.SelectMany(r => r.Values));
            remainingUrls = remainingUrls.Skip(partitionSize).ToList();
        }
        while (remainingUrls.Any());

        return result;
    }
    
    public async Task<IList<T>> GetPagedList<T>(string url)
    {
        var result = new List<T>();

        //make first request and it will get available pages in the headers
        var pagedResponse = await _requestor.GetPage<T>(GetPagedUrl(url, 1));
        result.AddRange(pagedResponse.Values);

        var totalPages = (int)Math.Ceiling( (double)pagedResponse.TotalCount / (double)pagedResponse.Limit);
        if (totalPages <= 1)
        {
            return result;
        }

        return await GetTotalPagedList(url, totalPages, result);
    }
}