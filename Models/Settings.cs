using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Total_Script_Blocker_II.Models;

public class Settings
{
    [JsonPropertyName("type")] public SettingsType Type { get; set; }
        
    [JsonPropertyName("whitelist")] public BlockerAllowLists WhiteList { get; set; }
     
    [JsonPropertyName("reload")] public bool Reload { get; set; }

}