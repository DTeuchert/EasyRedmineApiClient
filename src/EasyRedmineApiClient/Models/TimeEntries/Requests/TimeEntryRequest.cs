using Newtonsoft.Json;

namespace EasyRedmineApiClient.Models.TimeEntries.Requests;

public sealed class TimeEntryRequest
{
    /// <summary>
    /// The project id of an time entry.
    /// </summary>
    [JsonProperty("project_id")]
    public int ProjectId { get; }
    
    /// <summary>
    /// The issue id of an time entry.
    /// </summary>
    [JsonProperty("issue_id")]
    public int IssueId { get; set; }
    
    /// <summary>
    /// The user id of an time entry.
    /// </summary>
    [JsonProperty("user_id")]
    public int UserId { get; set; }
    
    /// <summary>
    /// The priority id of an time entry.
    /// </summary>
    [JsonProperty("priority_id")]
    public int PriorityId { get; set; }
    /// <summary>
    /// The activity id of an time entry.
    /// </summary>
    [JsonProperty("activity_id")]
    public int ActivityId { get; }
    
    /// <summary>
    /// The amount of spent hours.
    /// </summary>
    [JsonProperty("hours")]
    public string Hours { get; }

    /// <summary>
    /// The date of spent time.
    /// </summary>
    [JsonProperty("spent_on")]
    public string SpentOn { get; }

    /// <summary>
    /// The comments of an time entry.
    /// </summary>
    [JsonProperty("comments")]
    public string? Comments { get; set; }
    
    public TimeEntryRequest(int projectId, string hours, string spentOn, int activityId)
    {
        ProjectId = projectId;
        Hours = hours;
        SpentOn = spentOn;
        ActivityId = activityId;
    }
}