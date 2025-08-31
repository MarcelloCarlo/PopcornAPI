using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TCSTest.Models;

public class Schedule
{
    // "channelId": "9c2c75ac-fa11-4464-af11-da56f191e748",
    // "contentId": "61d9c6a6-c5fe-4b98-86f3-64c379287d4e",
    // "airTime": "2025-07-10T00:19:57.824680",
    // "endTime": "2025-07-01T03:07:57.824680"
    [JsonPropertyName("channelId")]
    public Guid ChannelId { get; set; }
    [JsonPropertyName("contentId")]
    public Guid ContentId { get; set; }
    [JsonPropertyName("airTime")]
    public DateTime AirTime { get; set; }
    [JsonPropertyName("endTime")]
    public DateTime EndTime { get; set; }
    [AllowNull]
    public virtual Channel? Channel { get; set; }
    [AllowNull]
    public virtual Content? Content { get; set; }
}