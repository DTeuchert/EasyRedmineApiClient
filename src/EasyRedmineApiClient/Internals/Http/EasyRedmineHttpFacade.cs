using System.Net;
using EasyRedmineApiClient.Internals.Http.Serialization;

namespace EasyRedmineApiClient.Internals.Http;

internal sealed class EasyRedmineHttpFacade
{
    private const string PrivateToken = "X-Redmine-API-Key";
    
    private readonly HttpClient _httpClient;
    
    private EasyRedmineApiRequestor _requestor;
    private EasyRedmineApiPagedRequestor _pagedRequestor;

    private EasyRedmineHttpFacade(string hostUrl, RequestJsonSerializer jsonSerializer,
        HttpMessageHandler httpMessageHandler, TimeSpan? clientTimeout = null)
    {
       _httpClient = new HttpClient(httpMessageHandler ?? new HttpClientHandler()) { BaseAddress = new Uri(hostUrl) };

        if (clientTimeout.HasValue)
        {
            _httpClient.Timeout = clientTimeout.Value;
        }

        Setup(jsonSerializer);
    }
    public EasyRedmineHttpFacade(string hostUrl, RequestJsonSerializer jsonSerializer, string authenticationToken = "", HttpMessageHandler httpMessageHandler = null, TimeSpan? clientTimeout = null) 
        : this(hostUrl, jsonSerializer, httpMessageHandler, clientTimeout)
    {
        _httpClient.DefaultRequestHeaders.Add(PrivateToken, authenticationToken);
    }

    private void Setup(RequestJsonSerializer jsonSerializer)
    {
        // allow tls 1.1 and 1.2
        ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

        _requestor = new EasyRedmineApiRequestor(_httpClient, jsonSerializer);
        _pagedRequestor = new EasyRedmineApiPagedRequestor(_requestor);
    }

    public Task<T> Get<T>(string uri) 
        => _requestor.Get<T>(uri);
    
    public Task<IList<T>> GetPagedList<T>(string uri) 
        => _pagedRequestor.GetPagedList<T>(uri);
    
    public Task<T> Post<T>(string uri, object data = null)
        => _requestor.Post<T>(uri, data);

    public Task Post(string uri, object data = null) 
        => _requestor.Post(uri, data);
    
    public Task<T> Put<T>(string uri, object data) 
        => _requestor.Put<T>(uri, data);

    public Task Put(string uri, object data) 
        => _requestor.Put(uri, data);

    public Task Delete(string uri) 
        => _requestor.Delete(uri);
    public Task Delete(string uri, object data) 
        => _requestor.Delete(uri, data);
}