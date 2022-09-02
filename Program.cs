using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Total_Script_Blocker_II;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

builder.Services.AddOidcAuthentication(options =>
                                       {
                                           // Configure your authentication provider options here.
                                           // For more information, see https://aka.ms/blazor-standalone-auth
                                           builder.Configuration.Bind("Local", options.ProviderOptions);
                                       });

builder.Services.AddBrowserExtensionServices();
await builder.Build().RunAsync();