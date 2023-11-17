using EasyRedmineApiClient.Internals.Http;
using EasyRedmineApiClient.Internals.Queries;
using EasyRedmineApiClient.Models.TimeEntries.Requests;
using EasyRedmineApiClient.Models.TimeEntries.Responses;

namespace EasyRedmineApiClient.Clients;

public sealed class TimeEntryClient : ITimeEntryClient
{
    private readonly EasyRedmineHttpFacade _httpFacade;
    private readonly TimeEntryQueryBuilder _queryBuilder;

    internal TimeEntryClient(EasyRedmineHttpFacade httpFacade, TimeEntryQueryBuilder queryBuilder)
    {
        _httpFacade = httpFacade;
        _queryBuilder = queryBuilder;
    }
    
    public async Task<IList<TimeEntry>> GetAllAsync(Action<TimeEntriesQueryOptions> options = null)
    {
        var queryOptions = new TimeEntriesQueryOptions();
        options?.Invoke(queryOptions);
        
        var url = _queryBuilder.Build("time_entries.json", queryOptions);
        return await _httpFacade.GetPagedList<TimeEntry>(url);
    }

    public async Task<TimeEntry> CreateAsync(CreateTimeEntryRequest request)
        => await _httpFacade.Post<TimeEntry>($"time_entries.json", request);
}