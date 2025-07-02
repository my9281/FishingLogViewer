using FishingLogMVC.Core;
using FishingLogMVC.Interfaces;
using FishingLogMVC.Middlewares;
using FishingLogMVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.WebSockets;
using System.Net.WebSockets;
namespace FishingLogMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TransInfos.Init();
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped(typeof(INoSQLDB<>), typeof(NoSQLDBService<>));
            builder.Services.AddScoped(typeof(ICookiesService<>), typeof(CookiesService<>));
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => options.LoginPath = "/Users/Login");
            builder.Services.AddControllersWithViews(options => options.Filters.Add<LanguageFilter>());

            builder.Services.AddSingleton<WebSocketConnectionManager>();

            var app = builder.Build();

            app.UseWebSockets();
            app.UseMiddleware<FishWebSocketMiddleware>();


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseWebSockets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{lan?}")
                .WithStaticAssets();
            app.UseRouting();
            app.UseAuthorization();
            app.MapStaticAssets();
            app.Run();
        } 
    }
}
