using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net.WebSockets;
using FishingLogMVC.Models;
using Newtonsoft.Json;
namespace FishingLogMVC.Core
{
    public class WebSocketConnectionManager
    {
        private readonly ConcurrentDictionary<string, WebSocket> _sockets = new();

        public void AddSocket(string key, WebSocket socket)
        {
            _sockets.TryAdd(key, socket);
        }

        public void RemoveSocket(string key)
        {
            _sockets.TryRemove(key, out _);
        }

        public WebSocket GetSocketByKey(string key)
        {
            _sockets.TryGetValue(key, out var socket);
            return socket;
        }

        public IEnumerable<string> GetAllKeys() => _sockets.Keys;

        internal async Task ProcessMessageAsync(string socketId, string msg)
        {

            WebSocketModel m = new WebSocketModel();
            m.Id = socketId;
            m.Data = msg;
            m.Time = DateTime.UtcNow;
            m.Status = "OK";
            await Request(socketId, JsonConvert.SerializeObject(m));
            return;
        }

        private async Task Request(string socketId, string msg)
        {
            if (_sockets.TryGetValue(socketId, out var socket))
            {
                if (socket.State == WebSocketState.Open)
                {
                    var bytes = System.Text.Encoding.UTF8.GetBytes(msg);
                    await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }

        public async void Accept(string id)
        {
            if (_sockets.TryGetValue(id, out var socket))
            {
                if (socket.State == WebSocketState.Open)
                {
                    WebSocketModel m = new WebSocketModel();
                    m.Id = id;
                    m.Data = "1";
                    m.Time = DateTime.UtcNow;
                    m.Status = "Login";

                    var bytes = System.Text.Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(m));
                    await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }
    }
}
