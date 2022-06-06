using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.ModelFilter
{
    public class DocumentFilter : FilterBase
    {
        public int UserId { get; set; }
        public int? Type { get; set; }
        public int? Status { get; set; }
        public string FileName { get; set; }
        public int DocumentTypeId { get; set; }
    }
}
