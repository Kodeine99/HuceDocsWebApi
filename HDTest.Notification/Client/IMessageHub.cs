using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HuceDocs.Notification.Client
{
    public interface IMessageHub
    {
        Task Send(string action, string message);
        Task SendUpdateDocumentStatus(int userid, int documentId, int status);
    }
}
