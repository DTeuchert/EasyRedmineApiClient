using EasyRedmineApiClient.Internals.Http;
using EasyRedmineApiClient.Internals.Queries;
using EasyRedmineApiClient.Models.Issues.Requests;
using EasyRedmineApiClient.Models.Issues.Responses;

namespace EasyRedmineApiClient.Clients;

public sealed class IssueClient : IIssueClient
{
    private readonly EasyRedmineHttpFacade _httpFacade;
    private readonly IssueQueryBuilder _queryBuilder;

    internal IssueClient(EasyRedmineHttpFacade httpFacade, IssueQueryBuilder queryBuilder)
    {
        _httpFacade = httpFacade;
        _queryBuilder = queryBuilder;
    }
    
    public async Task<Issue> GetAsync(int issueId) 
        => await _httpFacade.Get<Issue>($"issues/{issueId}.json");
    
    public async Task<IList<Issue>> GetAllAsync(Action<IssuesQueryOptions> options = null)
    {
        var queryOptions = new IssuesQueryOptions();
        options?.Invoke(queryOptions);
        
        var url = _queryBuilder.Build("issues.json", queryOptions);
        return await _httpFacade.GetPagedList<Issue>(url);
    }
}