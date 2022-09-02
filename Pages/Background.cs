using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExtensions.Net.Tabs;
using WebExtensions.Net.Windows;

namespace Total_Script_Blocker_II.Pages;

public partial class Background
{
    /// <summary>
    /// Open options.html and close other instance
    /// </summary>
    private async Task ShowOptionsPage()
    {
        try
        {
            var windows = (await WebExtensions.Windows.GetAll(new GetAllGetInfo() {AdditionalData = new Dictionary<string, object>() 
                                                                      {{"populate", true}}})).ToArray();
            
            for (var i = windows.Length - 1; i >= 0; i--)
            {
#pragma warning disable CS0618
                var optionsPageUrl = await WebExtensions.Extension.GetURL("options.html");
#pragma warning restore CS0618
                
                var window    = windows[i];
                
                var    tabsArray = window.Tabs.ToArray();
                for (var j = window.Tabs.ToArray().Length - 1; j >= 0; j--)
                {
                    var currentWindow = tabsArray[j];
                    if (!currentWindow.Url.Equals(optionsPageUrl)) continue;
                    var id = currentWindow.Id;
                    if (id is not null) await WebExtensions.Tabs.Remove(id.Value);
                }
                await WebExtensions.Tabs.Create(new CreateProperties() {Url = optionsPageUrl});
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}