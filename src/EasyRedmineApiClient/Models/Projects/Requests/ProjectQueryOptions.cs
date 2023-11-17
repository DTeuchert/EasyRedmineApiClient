namespace EasyRedmineApiClient.Models.Projects.Requests;

public class ProjectQueryOptions
{
    /// <summary>
    /// Return project includes list of tracker.
    /// </summary>
    public bool IncludeTrackers { get; set; } = false;

    /// <summary>
    /// Return project includes list of time entry activities.
    /// </summary>
    public bool IncludeTimeEntryActivities { get; set; } = false;
}