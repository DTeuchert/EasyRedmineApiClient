using Newtonsoft.Json;

namespace EasyRedmineApiClient.Models.TimeEntries.Requests;

public sealed class CreateTimeEntryRequest
{
    public CreateTimeEntryRequest(TimeEntryRequest request)
        => TimeEntry = request;
    
    /// <summary>
    /// The Wrapper of an time entry.
    /// </summary>
    [JsonProperty("time_entry")]
    public TimeEntryRequest TimeEntry { get; }
}