using EasyRedmineApiClient.Models.TimeEntries.Requests;
using EasyRedmineApiClient.Models.TimeEntries.Responses;

namespace EasyRedmineApiClient.Clients;

public interface ITimeEntryClient
{
     /// <summary>
    /// Retrieves time entries.
    /// </summary>
    /// <param name="options">Time entries retrieval options.</param>
    /// <returns>Time entries satisfying options.</returns>
    Task<IList<TimeEntry>> GetAllAsync(Action<TimeEntriesQueryOptions> options = null);
     
     /// <summary>
     /// Creates new time entry.
     /// </summary>
     /// <returns>The newly created time entry.</returns>
     /// <param name="request">Create time entry request.</param>
     Task<TimeEntry> CreateAsync(CreateTimeEntryRequest request);
}