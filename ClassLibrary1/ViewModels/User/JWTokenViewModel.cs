using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.ViewModels.User
{
    public class JWTokenViewModel
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string HostName { get; set; }
        public string IpAddress { get; set; }
        public int Type { get; set; }
        public int? Status { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
    public class JWTGenerateModel
    {
        public int UserId { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
