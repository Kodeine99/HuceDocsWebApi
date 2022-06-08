using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuceDocs.Notification.Client
{
    public class MessageHub : Hub, IMessageHub
    {
        private readonly IHubContext<MessageHub> _messageHub;
        public MessageHub(IHubContext<MessageHub> messageHub)
        {
            _messageHub = messageHub;
        }

        public async Task Send(string action, string message)
        {
            await _messageHub.Clients.All.SendAsync(action, message);
        }

        public async Task SendUpdateDocumentStatus(int userid, int documentId, int status)
        {
            await _messageHub.Clients.All.SendAsync("UpdateDocumentStatus" + userid, documentId, status);
        }
    }
}
