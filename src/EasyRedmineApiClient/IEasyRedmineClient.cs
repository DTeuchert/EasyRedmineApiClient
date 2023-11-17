using EasyRedmineApiClient.Clients;

namespace EasyRedmineApiClient;

public interface IEasyRedmineClient
{
    /// <summary>
    /// Access EasyRedmine's issues API.
    /// </summary>
    IIssueClient Issues { get; }
    
    /// <summary>
    /// Host address of EasyRedmine instance.
    /// </summary>
    string HostUrl { get; }
}