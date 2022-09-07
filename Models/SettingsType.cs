using System.Text.Json.Serialization;

namespace Total_Script_Blocker_II.Models;

public enum SettingsType
{
    [JsonPropertyName("create settings")]
    Create,
    [JsonPropertyName("read settings")]
    Read,
    [JsonPropertyName("update settings")]
    Update,
    [JsonPropertyName("delete settings")]
    Delete
}
