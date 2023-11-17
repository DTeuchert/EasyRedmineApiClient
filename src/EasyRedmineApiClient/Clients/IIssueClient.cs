using EasyRedmineApiClient.Models.Issues.Requests;
using EasyRedmineApiClient.Models.Issues.Responses;

namespace EasyRedmineApiClient.Clients;

public interface IIssueClient
{
    /// <summary>
    /// Retrieves project issue.
    /// </summary>
    /// <param name="issueId">Id of the issue.</param>
    Task<Issue> GetAsync(int issueId);
    
     /// <summary>
    /// Retrieves issues.
    /// By default retrieves opened issues from all users.
    /// </summary>
    /// <param name="options">Issues retrieval options.</param>
    /// <returns>Issues satisfying options.</returns>
    Task<IList<Issue>> GetAllAsync(Action<IssuesQueryOptions> options = null);
}