using HuceDocs.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.ViewModels.Category
{
    public class CategoryVM
    {
        public CategoryVM() { }
       
        public CategoryVM(DocumentType documentType)
        {
            Id = documentType.Id;
            Name = documentType.Name;
            Code = documentType.Code;
            Status = documentType.Status;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Status { get; set; }
        public int? TypeOfResult { get; set; }
    }
}
