using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TCSTest.Models;

public class Channel
{
    // "channelId": "65d8849e-4f77-4a87-a130-39e95df737a7",
    // "name": "FX HD",
    // "category": "TV Shows",
    // "language": "Malayalam",
    // "region": "USA"
    [JsonPropertyName("channelId")]
    public Guid ChannelId { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("category")]
    public string Category { get; set; }
    [JsonPropertyName("language")]
    public string Language { get; set; }
    [JsonPropertyName("region")]
    public string Region { get; set; }
}