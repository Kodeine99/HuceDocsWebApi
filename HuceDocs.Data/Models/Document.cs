﻿using HuceDocs.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Models
{
    public class Document : IEntity
    {
        public Document()
        {
            OutputExtensions = new HashSet<DocOutputExtensions>();
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? DocumentTypeId { get; set; }
        public bool? IsDelete { get; set; }


        public string FileName { get; set; } = String.Empty;
        public string FilePath { get; set; } = String.Empty;
        public long? FileLength { get; set; }
        public string FileExtension { get; set; } = String.Empty;

        public DateTime CreateDate { get; set; } 
        public int Status { get; set; }
        public string Description { get; set; } = String.Empty;
        public int TotalOfPages { get; set; }
        public int TotalOfFields { get; set; }
        public double Amount { get; set; }

        public virtual User User { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public virtual ICollection<DocOutputExtensions> OutputExtensions { get; set; }
        public virtual Verify Verify { get; set; }
    }
}
