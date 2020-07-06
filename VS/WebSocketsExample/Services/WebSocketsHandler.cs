using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketsExample.Services
{
    public class WebSocketsHandler
    {
        public ConcurrentDictionary<Guid, WebSocket> websocketConnections = new ConcurrentDictionary<Guid, WebSocket>();


        public async Task HandleAsync(Guid connectionId, WebSocket webSocket, String name )
        {
            

            websocketConnections.TryAdd(connectionId, webSocket);

            await SendMessageToSockets($"User with id <b>{name}</b> has joined the chat");

            while (webSocket.State == WebSocketState.Open)
            {
                var message = await ReceiveMessage(name, webSocket);
                if (message != null)
                    await SendMessageToSockets(message);
            }
        }

        private async Task<string> ReceiveMessage(String name, WebSocket webSocket)
        {
            var arraySegment = new ArraySegment<byte>(new byte[4096]);
            var receivedMessage = await webSocket.ReceiveAsync(arraySegment, CancellationToken.None);
            if (receivedMessage.MessageType == WebSocketMessageType.Text)
            {
                var message = Encoding.Default.GetString(arraySegment).TrimEnd('\0');
                if (!string.IsNullOrWhiteSpace(message))
                    return $"<b>{name}</b>: {message}";
            }
            return null;
        }

        private async Task SendMessageToSockets(string message)
        {
            foreach (var connection in websocketConnections.Values)
            {
                var arraySegment = new ArraySegment<byte>(Encoding.Default.GetBytes(message));
                await connection.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
