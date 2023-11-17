using Newtonsoft.Json;

namespace EasyRedmineApiClient.Models;

public sealed class Tracker
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}