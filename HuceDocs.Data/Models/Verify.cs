using HuceDocs.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Models
{
    public class Verify : IEntity
    {
        public int Id { get; set; }

        public int? DocumentId { get; set; }
        public string Url { get; set; } = String.Empty;
        public DateTime CreateTime { get; set; }
        public bool Active { get; set; }

        public virtual Document? Document { get; set; }
    }
}
