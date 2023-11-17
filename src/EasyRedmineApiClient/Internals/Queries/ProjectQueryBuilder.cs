using EasyRedmineApiClient.Models.Projects.Requests;

namespace EasyRedmineApiClient.Internals.Queries;

internal class ProjectQueryBuilder : QueryBuilder<ProjectQueryOptions>
{
    protected override void BuildCore(Query query, ProjectQueryOptions options)
    {
        if (!options.IncludeTrackers && !options.IncludeTimeEntryActivities) return;
        
        var value = "";
        if (options.IncludeTrackers)
        {
            value += "trackers";
        }
        if (options.IncludeTimeEntryActivities)
        {
            if (value.Length>0)
            {
                value += ",";
            }
            value += "time_entry_activities";
        }
            
        query.Add("include", value);
    }
}