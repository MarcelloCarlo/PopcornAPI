
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TCSTest.Models;

public class Content
{
    // "contentId": "5b848ac2-120e-4ce5-b28f-c8325c2eb5b2",
    // "title": "Interstellar - S2E11",
    // "type": "Movie",
    // "genre": "Sci-Fi",
    // "durationMinutes": 90,
    // "rating": "R18+",
    // "year": 2022,
    // "season": 5,
    // "episode": 4
    [JsonPropertyName("contentId")]
    public Guid ContentId { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("genre")]
    public string Genre { get; set; }
    [JsonPropertyName("durationMinutes")]
    public int DurationMinutes { get; set; }
    [JsonPropertyName("rating")]
    public string Rating { get; set; }
    [JsonPropertyName("year")]
    public int Year { get; set; }
    [JsonPropertyName("season")]
    public int? Season { get; set; }
    [JsonPropertyName("episode")]
    public int? Episode { get; set; }
}
