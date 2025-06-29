﻿using Microsoft.AspNetCore.Mvc;
using WebApplication3.Services;

namespace WebApplication4.Controllers
{
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IMessageService _messaging;
        private ILogger<ChatController> _logger;

        public ChatController(IMessageService messaging, ILogger<ChatController> logger)
        {
            _messaging = messaging;
            _logger = logger;
        }

        [HttpPost]
        [Route($"{nameof(SendMessage)}")]
        public async Task SendMessage(string message, Guid channel)
        {
            _logger.LogInformation(message, channel);

            await _messaging.Initialization;
            await _messaging.SendAsync(message, channel);
        }

        [HttpGet]
        [Route($"{nameof(ReceiveFromChannel)}")]
        public async Task ReceiveFromChannel(Guid channel)
        {
            await _messaging.Initialization;

            await _messaging.ReceiveFromChannel(channel);
        }

        [HttpGet]

        [Route($"{nameof(guid)}")]
        public string guid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
