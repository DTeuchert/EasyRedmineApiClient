using EasyRedmineApiClient.Models.Projects.Requests;
using EasyRedmineApiClient.Models.Projects.Responses;

namespace EasyRedmineApiClient.Clients;

public interface IProjectClient
{
    /// <summary>
    /// Retrieves a project.
    /// </summary>
    /// <param name="projectId">Id of the project.</param>
    Task<Project> GetAsync(int projectId, Action<ProjectQueryOptions> options = null);
    
     /// <summary>
    /// Retrieves projects.
    /// </summary>
    /// <returns>Projects of the user.</returns>
    Task<IList<Project>> GetAllAsync();
}