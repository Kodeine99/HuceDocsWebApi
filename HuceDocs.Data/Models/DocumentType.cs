using HuceDocs.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Models
{
    public class DocumentType : IEntity
    {
        public DocumentType()
        {
            Services = new HashSet<Document>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string FCCode { get; set; }
        public int? TotalOfField { get; set; }
        public int? Status { get; set; }

        //public int? TypeOfResult { get; set; }

        public DateTime UpdateDate { get; set; }
        //public int AdminId { get; set; }

        public ICollection<Document> Services { get; set; }
    }
}
