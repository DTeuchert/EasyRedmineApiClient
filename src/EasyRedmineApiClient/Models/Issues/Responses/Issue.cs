using Newtonsoft.Json;

namespace EasyRedmineApiClient.Models.Issues.Responses;

public sealed class Issue : ModifiableObject
{
    [JsonProperty("subject")]
    public string Subject { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
    
    [JsonProperty("estimated_hours")]
    public string EstimatedHours { get; set; }
    
    [JsonProperty("project")]
    public Project Project { get; set; }
    
    [JsonProperty("tracker")]
    public Tracker Tracker { get; set; }
    
    [JsonProperty("author")]
    public Author Author { get; set; }
    
    [JsonProperty("parent")]
    public Parent Parent { get; set; }
    
    [JsonProperty("activity")]
    public Activity Activity { get; set; }

    [JsonProperty("custom_fields")] 
    public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
}