global using EProdavnica.Shared;
global using Microsoft.EntityFrameworkCore;
global using EProdavnica.Server.Data;
global using EProdavnica.Server.Services.ProductService;
global using EProdavnica.Server.Services.Categories;
global using EProdavnica.Server.Services.CartService;
global using EProdavnica.Server.Services.AuthService;
global using Microsoft.AspNetCore.Components.Authorization;
using BlazorEcommerce.Client;

namespace EProdavnica;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IProizvodService, ProizvodService>();
        builder.Services.AddScoped<IKategorijaService, KategorijaService>();
        builder.Services.AddScoped<IKorpaService, KorpaService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddOptions();
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

        var app = builder.Build();

        app.UseSwaggerUI();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseSwagger();

        app.UseHttpsRedirection();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();


        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("index.html");

        app.Run();
    }
}
