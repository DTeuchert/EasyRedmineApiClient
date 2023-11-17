namespace EasyRedmineApiClient.Models.TimeEntries.Requests;

public class TimeEntriesQueryOptions
{
    /// <summary>
    /// Return time entries assigned to the given project id.
    /// </summary>
    public int? ProjectId { get; set; }
    
    /// <summary>
    /// Return time entries assigned to the given issue id.
    /// </summary>
    public int? IssueId { get; set; }
    
    /// <summary>
    /// Return time entries assigned to the given user id.
    /// </summary>
    public int? UserId { get; set; }
}