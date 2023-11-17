using EasyRedmineApiClient.Models.TimeEntries.Requests;

namespace EasyRedmineApiClient.Internals.Queries;

internal class TimeEntryQueryBuilder : QueryBuilder<TimeEntriesQueryOptions>
{
    protected override void BuildCore(Query query, TimeEntriesQueryOptions options)
    {
        query.Add("set_filter", 1);
        
        if (options.ProjectId.HasValue)
            query.Add("project_id", options.ProjectId.Value);
        
        if (options.IssueId.HasValue)
            query.Add("issue_id", options.IssueId.Value);
        
        if (options.UserId.HasValue)
            query.Add("user_id", options.UserId.Value);
    }
}