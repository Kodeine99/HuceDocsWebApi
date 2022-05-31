using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuceDocs.Data.Models
{
    public class OCR_Request : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string JsonData { get; set; } = String.Empty;
        public int UserId { get; set; }
        public DateTime CreateTime { get; set; }
        public string Token { get; set; } = String.Empty;
        public int OCR_Status { get; set; }

    }
}
