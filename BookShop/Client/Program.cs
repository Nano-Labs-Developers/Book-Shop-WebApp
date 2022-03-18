global using BookShop.Shared;
global using System.Net.Http.Json;
global using BookShop.Client.Services.BookServices;
global using BookShop.Client.Services.AuthService;
global using BookShop.Client.Services.CartService;
global using BookShop.Client.Services.OrderService;
global using BookShop.Client.Services.AddressService;
global using BookShop.Client.Services.CategoryService;
global using BookShop.Client.Services.BookTypeService;
global using Microsoft.AspNetCore.Components.Authorization;
using BookShop.Client;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IBookTypeService, BookTypeService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
