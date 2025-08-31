using System.Text.Json.Serialization;

namespace TCSTest.DTOs;

public class ChannelDTO
{
    [JsonPropertyName("channelId")]
    public Guid? ChannelId { get; set; }
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("category")]
    public required string Category { get; set; }
    [JsonPropertyName("language")]
    public required string Language { get; set; }
    [JsonPropertyName("region")]
    public required string Region { get; set; }
}