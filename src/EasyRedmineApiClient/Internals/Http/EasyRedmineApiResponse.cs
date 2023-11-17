using Newtonsoft.Json;

namespace EasyRedmineApiClient.Internals.Http;

internal sealed class EasyRedmineApiResponse<T>
{
    [JsonProperty("value")]
    public T Value { get; set; }
}