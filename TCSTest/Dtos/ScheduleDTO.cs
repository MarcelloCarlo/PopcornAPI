using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using TCSTest.Models;
using Channel = TCSTest.Models.Channel;

namespace TCSTest.DTOs;

public class ScheduleDTO
{
    [JsonPropertyName("channelId")]
    public Guid ChannelId { get; set; }
    [JsonPropertyName("contentId")]
    public Guid ContentId { get; set; }
    [JsonPropertyName("airTime")]
    public DateTime AirTime { get; set; }
    [JsonPropertyName("endTime")]
    public DateTime EndTime { get; set; }
    [AllowNull]
    public virtual ChannelDTO? Channel { get; set; }
    [AllowNull]
    public virtual ContentDTO? Content { get; set; }
}