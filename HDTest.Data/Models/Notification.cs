using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Models
{
    public class Notification : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FileName { get; set; }
        public string DocumentType { get; set; }
        public DateTime CreateDate { get; set; }
        public int? Status { get; set; }
        //public int? Type { get; set; }
        public bool Seen { get; set; }

        public virtual User User { get; set; }
    }
}
