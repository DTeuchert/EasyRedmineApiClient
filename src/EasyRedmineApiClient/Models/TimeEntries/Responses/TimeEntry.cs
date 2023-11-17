using Newtonsoft.Json;

namespace EasyRedmineApiClient.Models.TimeEntries.Responses;

public class TimeEntry : ModifiableObject
{
    [JsonProperty("project")]
    public Project Project { get; set; }
    
    [JsonProperty("issue")]
    public Issue Issue { get; set; }
    
    [JsonProperty("user")]
    public User User { get; set; }

    [JsonProperty("priority")]
    public Priority Priority { get; set; }
    
    [JsonProperty("hours")]
    public string Hours { get; set; }
    
    [JsonProperty("spent_on")]
    public DateTime SpentOn { get; set; }

    [JsonProperty("comments")]
    public string Comments { get; set; }
    
    [JsonProperty("custom_fields")] 
    public List<CustomField> CustomFields { get; set; } = new List<CustomField>();
}