using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Models
{
    public class HFile : IEntity
    {
        public HFile()
        {

        }

        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public int Status { get; set; }

        public virtual Document Document { get; set; }
    }
}
