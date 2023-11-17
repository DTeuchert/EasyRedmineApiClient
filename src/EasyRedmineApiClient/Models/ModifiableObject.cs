using Newtonsoft.Json;

namespace EasyRedmineApiClient.Models;

public class ModifiableObject
{
    internal ModifiableObject()
    {
    }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("created_on")]
    public DateTime CreatedOn { get; set; }
    
    [JsonProperty("updated_on")]
    public DateTime UpdatedOn { get; set; }
}