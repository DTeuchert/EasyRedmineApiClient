using Newtonsoft.Json;

namespace EasyRedmineApiClient.Models;

public sealed class CustomField
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("field_format")]
    public string FieldFormat { get; set; }
    
    [JsonProperty("value")]
    public object Value { get; set; }
}