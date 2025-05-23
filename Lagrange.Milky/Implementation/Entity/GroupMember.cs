using System.Text.Json.Serialization;

namespace Lagrange.Milky.Implementation.Entity;

public class GroupMember
{

    [JsonPropertyName("group_id")]
    public required long GroupId { get; init; }

    [JsonPropertyName("user_id")]
    public required long UserId { get; init; }

    [JsonPropertyName("nickname")]
    public required string Nickname { get; init; }

    [JsonPropertyName("card")]
    public required string Card { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("sex")]
    public required string Sex { get; init; }

    [JsonPropertyName("level")]
    public required int Level { get; init; }

    [JsonPropertyName("role")]
    public required string Role { get; init; }

    [JsonPropertyName("join_time")]
    public required long JoinTime { get; init; }

    [JsonPropertyName("last_sent_time")]
    public required long LastSentTime { get; init; }
}