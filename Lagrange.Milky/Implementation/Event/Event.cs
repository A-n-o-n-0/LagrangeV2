using System.Text.Json.Serialization;

namespace Lagrange.Milky.Implementation.Event;

public class Event
{
    [JsonPropertyName("time")]
    public required long Time { get; init; }

    [JsonPropertyName("self_id")]
    public required long SelfId { get; init; }

    [JsonPropertyName("event_type")]
    public required string EventType { get; init; }

    [JsonPropertyName("data")]
    public required object Data { get; init; }
}

