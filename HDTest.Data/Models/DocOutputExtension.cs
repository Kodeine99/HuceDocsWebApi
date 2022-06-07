using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Models
{
    public class DocOutputExtensions
    {
        public int DocumentId { get; set; }
        public int OutputExtensionId { get; set; }

        public Document Document { get; set; }
        //public OutputExtension OutputExtension { get; set; }
    }
}
