using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Models
{
    public class OutputResults : IEntity
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int? FileLength { get; set; }
        public string FileExtension { get; set; }
        
        public DateTime CreateDate { get; set; }

        public virtual Document Document { get; set; }
    }
}
