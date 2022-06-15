using HuceDocs.Services.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.ViewModels.Document
{
    public class DocumentVM
    {
        public DocumentVM()
        {

        }
        public DocumentVM(HuceDocs.Data.Models.Document entity)
        {
            Id = entity.Id;
            UserId = entity.UserId;
            IsDelete = entity.IsDelete;


            CreateDate = entity.CreateDate;
            Status = entity.Status;
            Description = entity.Description;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? DocumentTypeId { get; set; }
        public bool? IsDelete { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long? FileLength { get; set; }
        public string FileExtension { get; set; }

        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public int TotalOfPages { get; set; }
        public int TotalOfFields { get; set; }
        public CategoryVM DocumentType { get; set; }

    }

    public class EmployeeDocumentModel : DocumentVM
    {
        public string UserName { get; set; }
        public string DocumentTypeName { get; set; }
    }
}

