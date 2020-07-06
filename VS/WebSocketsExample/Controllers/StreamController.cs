﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketsExample.Services;

namespace WebSocketsExample.Controllers
{
    public class StreamController : Controller
    {
        private WebSocketsHandler _handler;

        public StreamController(WebSocketsHandler handler)
        {
            _handler = handler;
        }


        public async Task Get()
        {
            var context = ControllerContext.HttpContext;
            var isWebSocketRequest = context.WebSockets.IsWebSocketRequest;

            if (isWebSocketRequest)
            {
                WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                await _handler.HandleAsync(Guid.NewGuid(), webSocket, (string)TempData["UserName"]);
                //await SendMessage(webSocket);
            }
            else
            {
                context.Response.StatusCode = 400;
            }
        }

        private async Task SendMessage(WebSocket webSocket)
        {
            for (int i = 0; ;i++)
            {
                var bytes = Encoding.ASCII.GetBytes("Message" + i);
                await webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                Thread.Sleep(1000);
            }
        }
    }
}
