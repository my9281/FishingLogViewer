using FishingLogMVC.Core;
using System.Net.WebSockets;

namespace FishingLogMVC.Middlewares
{
    public class FishWebSocketMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebSocketConnectionManager _manager;

        public FishWebSocketMiddleware(RequestDelegate next, WebSocketConnectionManager manager)
        {
            _next = next;
            _manager = manager;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/ws")
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    var socket = await context.WebSockets.AcceptWebSocketAsync();
                    var socketId = Guid.NewGuid().ToString();
                    _manager.AddSocket(socketId, socket);

                    await HandleSocket(socket, socketId);

                    _manager.RemoveSocket(socketId);
                }
                else
                {
                    context.Response.StatusCode = 400;
                }
            }
            else
            {
                await _next(context);
            }
        }

        private async Task HandleSocket(WebSocket socket, string socketId)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                var msg = System.Text.Encoding.UTF8.GetString(buffer, 0, result.Count);

                // 交给 manager 处理
                await _manager.ProcessMessageAsync(socketId, msg);

                // 继续接收
                result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await socket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}