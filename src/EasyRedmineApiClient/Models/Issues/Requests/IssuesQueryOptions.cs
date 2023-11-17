namespace EasyRedmineApiClient.Models.Issues.Requests;

public class IssuesQueryOptions
{
    /// <summary>
    /// Return issues assigned to the given project id.
    /// </summary>
    public int? ProjectId { get; set; }
    
    /// <summary>
    /// Return issues assigned to the given tracker id.
    /// </summary>
    public int? TrackerId { get; set; }
}