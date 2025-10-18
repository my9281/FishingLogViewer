using FishingLogMVC.Core;
using FishingLogMVC.Interfaces;
using FishingLogMVC.Middlewares;
using FishingLogMVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.StaticFiles;
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
            if (!app.Environment.IsDevelopment()) app.UseExceptionHandler("/Home/Error"); 
            app.UseWebSockets();
            app.MapControllerRoute(
                name: "FishLog",
                pattern: "{controller=Home}/{action=Index}/{lan?}")
                .RequireHost("fishlog.ymforever.com") 
                .WithStaticAssets();
            app.MapControllerRoute(
               name: "CMS",
               pattern: "{controller=CMS}/{action=Index}/{lan?}")
               .RequireHost("cms.ymforever.com")
               .WithStaticAssets();
            app.MapControllerRoute(
               name: "YMCU",
               pattern: "{controller=YMCU}/{action=Index}/{lan?}")
               .RequireHost("ymcu.ymforever.com")
               .WithStaticAssets();
            app.MapControllerRoute(
               name: "Rusume",
               pattern: "{controller=Rusume}/{action=Index}/{lan?}")
               .RequireHost("resume.ymforever.com")
               .WithStaticAssets(); 
            app.MapControllerRoute(
               name: "Main",
               pattern: "{controller=Main}/{action=Index}/{lan?}")
               .RequireHost("www.ymforever.com","ymforever.com")
               .WithStaticAssets();
            app.UseRouting();
            app.UseAuthorization();


            app.MapStaticAssets();
            app.Run();
        }
    }
}
