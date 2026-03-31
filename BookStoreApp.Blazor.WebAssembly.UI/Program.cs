using Blazored.LocalStorage;
using BookStoreApp.Blazor.WebAssembly.UI;
using BookStoreApp.Blazor.WebAssembly.UI.Configurations;
using BookStoreApp.Blazor.WebAssembly.UI.Providers;
using BookStoreApp.Blazor.WebAssembly.UI.Services;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Authentication;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7092") });

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<ApiAuthenticationStateProvider>());
builder.Services.AddAuthorizationCore();

builder.Services.AddHttpClient<IClient, Client>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthorService, AuthorServices>();
builder.Services.AddScoped<IBookService, BookServices>();

builder.Services.AddAutoMapper(typeof(MapperConfig));



await builder.Build().RunAsync();
