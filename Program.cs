using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using Lkhsoft.Utility;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Total_Script_Blocker_II.Services;

namespace Total_Script_Blocker_II
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#TotalScriptBlockerIIApp");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            /* Serilog configuration
 * here I use BrowserHttp sink to send log entries to my Server app
 */
            var levelSwitch = new LoggingLevelSwitch();
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.ControlledBy(levelSwitch)
                        .Enrich.WithProperty("InstanceId", Guid.NewGuid().ToString("n"))
                        .WriteTo.BrowserConsole(
                                                LogEventLevel.Information,
                                                "[{Timestamp:HH:mm:ss} {Level:u2}] {Message:lj}{NewLine}{Exception}", 
                                                CultureInfo.CurrentUICulture)
                        .CreateLogger();

/* this is used instead of .UseSerilog to add Serilog to providers */
            builder.Logging.AddSerilog();
            
            builder.Services.AddScoped<IJsonSerializer, JsonSerializer>();
            builder.Services.AddScoped<IBlocker, Blocker>();
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddBrowserExtensionServices();
            await builder.Build().RunAsync();
        }
    }
}
