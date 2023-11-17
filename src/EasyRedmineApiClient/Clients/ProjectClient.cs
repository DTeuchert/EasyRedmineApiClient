using EasyRedmineApiClient.Internals.Http;
using EasyRedmineApiClient.Internals.Queries;
using EasyRedmineApiClient.Models.Projects.Requests;
using EasyRedmineApiClient.Models.Projects.Responses;

namespace EasyRedmineApiClient.Clients;

public sealed class ProjectClient : IProjectClient
{
    private readonly EasyRedmineHttpFacade _httpFacade;
    private readonly ProjectQueryBuilder _queryBuilder;

    internal ProjectClient(EasyRedmineHttpFacade httpFacade, ProjectQueryBuilder queryBuilder)
    {
        _httpFacade = httpFacade;
        _queryBuilder = queryBuilder;
    }
    
    public async Task<Project> GetAsync(int projectId, Action<ProjectQueryOptions> options = null) {
        var queryOptions = new ProjectQueryOptions();
        options?.Invoke(queryOptions);
        
        var url = _queryBuilder.Build($"projects/{projectId}.json", queryOptions);
        return await _httpFacade.Get<Project>(url);
    }

    public async Task<IList<Project>> GetAllAsync()
        => await _httpFacade.GetPagedList<Project>("projects.json");
}