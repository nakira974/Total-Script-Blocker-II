using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Total_Script_Blocker_II.Models;

public class BlockerAllowLists
{
    [JsonPropertyName("whitelist")] public IEnumerable<string> WhiteList { get; set; }
        
    [JsonPropertyName("whitelistHash")] public string WhiteListHash { get; set; }
        
    [JsonPropertyName("tempAllowList")] public IEnumerable<string> TempList { get; set; }
        
    [JsonPropertyName("tempAllowListHash")] public string TempListHash { get; set; }
        
    [JsonPropertyName("globalAllowAll")] public bool GlobalAllowAll { get; set; }
        
    [JsonPropertyName("tempExpiry")] public DateTime TempExpiry { get; set; }
        
    [JsonPropertyName("blacklist")] public IEnumerable<string> BlackList { get; set; }
        
    [JsonPropertyName("blacklistHash")] public string BlackListHash { get; set; }
}