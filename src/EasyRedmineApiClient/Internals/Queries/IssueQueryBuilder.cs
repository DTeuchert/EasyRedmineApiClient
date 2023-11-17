using EasyRedmineApiClient.Models.Issues.Requests;

namespace EasyRedmineApiClient.Internals.Queries;

internal class IssueQueryBuilder : QueryBuilder<IssuesQueryOptions>
{
    protected override void BuildCore(Query query, IssuesQueryOptions options)
    {
        query.Add("set_filter", 1);
        
        if (options.ProjectId.HasValue)
            query.Add("project_id", options.ProjectId.Value);
        
        if (options.TrackerId.HasValue)
            query.Add("tracker_id", options.TrackerId.Value);
    }
}