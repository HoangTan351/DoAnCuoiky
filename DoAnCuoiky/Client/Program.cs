global using DoAnCuoiky.Client.Services.GameServices;
global using DoAnCuoiky.Client.Services.SinhvienServices;
global using DoAnCuoiky.Client.Services.ExcelServices;
global using DoAnCuoiky.Shared.Models;
global using DoAnCuoiky.Shared;
global using System.Net.Http.Json;
using DoAnCuoiky.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("DoAnCuoiky.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("DoAnCuoiky.ServerAPI"));
builder.Services.AddScoped<IGameServices, GameServices>();
builder.Services.AddScoped<ISinhvienService, SinhvienService>();
builder.Services.AddScoped<IExcelService, ExcelService>();
builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
