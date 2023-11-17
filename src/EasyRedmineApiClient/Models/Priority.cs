﻿using Newtonsoft.Json;

namespace EasyRedmineApiClient.Models;

public sealed class Priority
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}