using Newtonsoft.Json;

namespace EasyRedmineApiClient.Internals.Http;

internal sealed class EasyRedmineApiPagedResponse<T>
{
    [JsonProperty("value")]
    public List<T> Values { get; set; } = new ();

    [JsonProperty("total_count")]
    public int TotalCount { get; set; }
    
    [JsonProperty("offset")]
    public int Offset { get; set; }
    
    [JsonProperty("limit")]
    public int Limit { get; set; }
}