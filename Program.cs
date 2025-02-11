using kanavrt;
using kanavrt.Controller.Modes;
using kanavrt.Model;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<KanaModel>();

builder.Services.AddTransient<EitherOrModeController>();
builder.Services.AddTransient<KeyboardModeController>();

await builder.Build().RunAsync();
