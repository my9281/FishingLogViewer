using FishingLogMVC.Core;
using FishingLogMVC.Interfaces;
using FishingLogMVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Globalization;

namespace FishingLogMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TransInfos.Init();
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor(); // 注入 HttpContext 
            builder.Services.AddScoped(typeof(INoSQLDB<>), typeof(NoSQLDBService<>));
            builder.Services.AddScoped(typeof(ICookiesService<>), typeof(CookiesService<>));
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
    {
        options.LoginPath = "/Users/Login";
    });
            builder.Services.AddControllersWithViews(options =>
    {
        options.Filters.Add<LanguageFilter>();
    });
            var app = builder.Build();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            } 
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
