global using EProdavnica.Shared;
global using System.Net.Http.Json;
global using EProdavnica.Client.Services.ProductService;
global using EProdavnica.Client.Services.CategoryService;
global using EProdavnica.Client.Services.CartService;
global using EProdavnica.Client.Services.AuthService;
global using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using BlazorEcommerce.Client;



namespace EProdavnica.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            
            builder.RootComponents.Add<App>("#app");
            
            builder.RootComponents.Add<HeadOutlet>("head::after");
            
            builder.Services.AddBlazoredLocalStorage();
            
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            builder.Services.AddScoped<IProizvodService, ProizvodService>();
            
            builder.Services.AddScoped<IKategorijaService, KategorijaService>();

            builder.Services.AddScoped<IKorpaService, KorpaService>();

            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddOptions();

            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

            await builder.Build().RunAsync();
        }
    }
}
