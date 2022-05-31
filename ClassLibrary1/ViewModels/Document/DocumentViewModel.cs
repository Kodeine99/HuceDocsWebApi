using HuceDocs.Data.Models;
using HuceDocs.Services.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.ViewModels.Document
{
    public class DocumentViewModel
    {
        public DocumentViewModel()
        {

        }
        public DocumentViewModel(HuceDocs.Data.Models.Document entity)
        {
            Id = entity.Id;
            UserId = entity.UserId;
            DocumentTypeId = entity.DocumentTypeId;
            IsDelete = entity.IsDelete;

            FileName = entity.FileName;
            FilePath = entity.FilePath;
            FileLength = entity.FileLength;
            FileExtension = entity.FileExtension;

            CreateDate = entity.CreateDate;
            Status = entity.Status;
            Description = entity.Description;
            TotalOfPages = entity.TotalOfPages;
            TotalOfFields = entity.TotalOfFields;
            Amount = entity.Amount;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }
        public int? LanguageId { get; set; }
        public int? DocumentTypeId { get; set; }
        public bool? IsDelete { get; set; }

        public int? CheckType { get; set; }
        public int? FromPage { get; set; }
        public int? ToPage { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long? FileLength { get; set; }
        public string FileExtension { get; set; }

        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public int TotalOfPages { get; set; }
        public int TotalOfFields { get; set; }
        public double Amount { get; set; }

        public int? TypeOfResult { get; set; }
    }

    public class EmployeeDocumentModel : DocumentViewModel
    {
        public string UserName { get; set; }
        public string DocumentTypeName { get; set; }
    }
}
