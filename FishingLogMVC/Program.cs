using FishingLogMVC.Core;
using FishingLogMVC.Interfaces;
using FishingLogMVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Globalization;
using System.Net.WebSockets;
using System.Text;
using System.Threading;

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
            builder.Services.AddWebSockets(options =>
            {
                options.KeepAliveInterval = TimeSpan.FromSeconds(120);
            });
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
            app.UseWebSockets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{lan?}")
                .WithStaticAssets();
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/ws")
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                        await Echo(webSocket);
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                    }
                }
                else
                {
                    await next();
                }
            });
            app.UseRouting();
            app.UseAuthorization();
            app.MapStaticAssets();
            app.Run();
        }
        private static async Task Echo(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}
