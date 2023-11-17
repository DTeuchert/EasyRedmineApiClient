using EasyRedmineApiClient.Clients;
using EasyRedmineApiClient.Internals.Http;
using EasyRedmineApiClient.Internals.Http.Serialization;
using EasyRedmineApiClient.Internals.Queries;
using EasyRedmineApiClient.Internals.Utilities;

namespace EasyRedmineApiClient;

public sealed class EasyRedmineClient : IEasyRedmineClient
{
    
    /// <summary>
    /// Access EasyRedmine's project API.
    /// </summary>
    public IProjectClient Projects { get; }
    
    /// <summary>
    /// Access EasyRedmine's issues API.
    /// </summary>
    public IIssueClient Issues { get; }
    
    /// <summary>
    /// Access EasyRedmine's time entry API.
    /// </summary>
    public ITimeEntryClient TimeEntries { get; }
    
    /// <summary>
    /// Host address of EasyRedmine instance.
    /// </summary>
    public string HostUrl { get; }
    
    /// <summary>
    /// Creates a new instance of the EasyRedmine API client pointing to the specified hostUrl.
    /// </summary>
    /// <param name="hostUrl">Host address of EasyRedmine instance. For example https://www.easyredmine.com/</param>
    /// <param name="authenticationToken">Personal access token. Obtained from EasyRedmine profile settings.</param>
    /// <param name="httpMessageHandler">Optional handler for HTTP messages. Used for SSL pinning or canceling validation for example.</param>
    /// <param name="clientTimeout">Timespan with the HTTP client timeout if null default timeout is used.</param>
    public EasyRedmineClient(string hostUrl, string authenticationToken = "", HttpMessageHandler httpMessageHandler = null, TimeSpan? clientTimeout = null)
    {
        Guard.NotEmpty(hostUrl, nameof(hostUrl));
        Guard.NotNull(authenticationToken, nameof(authenticationToken));
        HostUrl = FixBaseUrl(hostUrl);

        var jsonSerializer = new RequestJsonSerializer();

        var httpFacade = new EasyRedmineHttpFacade(
            HostUrl,
            jsonSerializer,
            authenticationToken,
            httpMessageHandler,
            clientTimeout);

        Projects = new ProjectClient(httpFacade, new ProjectQueryBuilder());
        Issues = new IssueClient(httpFacade, new IssueQueryBuilder());
        TimeEntries = new TimeEntryClient(httpFacade, new TimeEntryQueryBuilder());
    }
    
    private static string FixBaseUrl(string url)
    {
        url = url.TrimEnd('/');
        return url + "/";
    }
}