using System.Text.Json.Serialization;

namespace TCSTest.DTOs;

public class ContentDTO
{
    [JsonPropertyName("contentId")]
    public Guid? ContentId { get; set; }
    [JsonPropertyName("title")]
    public required string Title { get; set; }
    [JsonPropertyName("type")]
    public required string Type { get; set; }
    [JsonPropertyName("genre")]
    public required string Genre { get; set; }
    [JsonPropertyName("durationMinutes")]
    public int DurationMinutes { get; set; }
    [JsonPropertyName("rating")]
    public required string Rating { get; set; }
    [JsonPropertyName("year")]
    public int Year { get; set; }
    [JsonPropertyName("season")]
    public int? Season { get; set; }
    [JsonPropertyName("episode")]
    public int? Episode { get; set; }
}

