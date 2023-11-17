using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using EasyRedmineApiClient.Internals.Http.Serialization;

namespace EasyRedmineApiClient.Internals.Http;

internal sealed class EasyRedmineApiRequestor
{
    private readonly HttpClient _httpClient;
    private readonly RequestJsonSerializer _jsonSerializer;

    public EasyRedmineApiRequestor(HttpClient httpClient, RequestJsonSerializer jsonSerializer)
    {
        _httpClient = httpClient;
        _jsonSerializer = jsonSerializer;
    }

    private static async Task EnsureSuccessStatusCode(HttpResponseMessage responseMessage)
    {
        if (responseMessage.IsSuccessStatusCode)
        {
            return;
        }

        var errorResponse = await responseMessage.Content.ReadAsStringAsync();
        throw new EasyRedmineException(responseMessage.StatusCode, errorResponse ?? "");
    }
    private async Task<T> ReadResponse<T>(HttpResponseMessage responseMessage)
    {
        var response = await responseMessage.Content.ReadAsStringAsync();
        response = Regex.Replace(response,"^(\\{\")(\\w*)(\":\\[?\\{.*\\}(?:,.*)?\\})$" , m => m.Groups[1].Value + "value" + m.Groups[3].Value);
        var result = _jsonSerializer.Deserialize<T>(response);
        return result;
    }
    private StringContent SerializeToString(object data)
    {
        var serializedObject = _jsonSerializer.Serialize(data);

        var content = data != null ?
            new StringContent(serializedObject) :
            new StringContent(string.Empty);

        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return content;
    }
    
    public async Task<T> Get<T>(string uri)
    {
        var responseMessage = await _httpClient.GetAsync(uri);
        await EnsureSuccessStatusCode(responseMessage);
        var responseObject = await ReadResponse<EasyRedmineApiResponse<T>>(responseMessage);
        return responseObject.Value;
    }
    
    public async Task<EasyRedmineApiPagedResponse<T>> GetPage<T>(string uri)
    {
        var responseMessage = await _httpClient.GetAsync(uri);
        try
        {
            await EnsureSuccessStatusCode(responseMessage);
        }
        catch (EasyRedmineException e)
        {
            if (e.HttpStatusCode is HttpStatusCode.NotFound)
            {
                return new EasyRedmineApiPagedResponse<T>();
            }

            throw;
        }
        return await ReadResponse<EasyRedmineApiPagedResponse<T>>(responseMessage);
    }
    
    public async Task<T> Post<T>(string url, object data = null)
    {
        StringContent content = SerializeToString(data);
        var responseMessage = await _httpClient.PostAsync(url, content);
        await EnsureSuccessStatusCode(responseMessage);
        return await ReadResponse<T>(responseMessage);
    }

    public async Task Post(string url, object data = null)
    {
        StringContent content = SerializeToString(data);
        var responseMessage = await _httpClient.PostAsync(url, content);
        await EnsureSuccessStatusCode(responseMessage);
    }
    public async Task<T> Put<T>(string url, object data)
    {
        StringContent content = SerializeToString(data);
        var responseMessage = await _httpClient.PutAsync(url, content);
        await EnsureSuccessStatusCode(responseMessage);
        return await ReadResponse<T>(responseMessage);
    }

    public async Task Put(string url, object data)
    {
        StringContent content = SerializeToString(data);
        var responseMessage = await _httpClient.PutAsync(url, content);
        await EnsureSuccessStatusCode(responseMessage);
    }

    public async Task Delete(string url)
    {
        var responseMessage = await _httpClient.DeleteAsync(url);
        await EnsureSuccessStatusCode(responseMessage);
    }

    public async Task Delete(string url, object data)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, url)
        {
            Content = SerializeToString(data)
        };
        var responseMessage = await _httpClient.SendAsync(request);
        await EnsureSuccessStatusCode(responseMessage);
    }
}