using Newtonsoft.Json;

namespace EasyRedmineApiClient.Models.Projects.Responses;

public sealed class Project : ModifiableObject
{
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("homepage")]
    public string Homepage { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
    
    [JsonProperty("parent")]
    public Parent Parent { get; set; }
    
    [JsonProperty("author")]
    public Author Author { get; set; }
    
    [JsonProperty("easy_start_date")]
    public DateTime StartDate { get; set; }
    
    [JsonProperty("easy_due_date")]
    public DateTime DueDate { get; set; }
    
    [JsonProperty("sum_time_entries")]
    public double SumTimeEntries { get; set; }
    
    [JsonProperty("sum_estimated_hours")]
    public double SumEstimatedHours { get; set; }

    [JsonProperty("trackers")]
    public List<Tracker> Trackers { get; set; } = new List<Tracker>();
    
    [JsonProperty("time_entry_activities")]
    public List<TimeEntryActivity> TimeEntryActivities { get; set; } = new List<TimeEntryActivity>();
}
