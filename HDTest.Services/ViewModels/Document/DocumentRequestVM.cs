using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HuceDocs.Services.ViewModels.Document
{
    public class DocumentRequestVM
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Loại dịch vụ không được bỏ trống")]
        public List<int> Types { get; set; }
        public List<int> LanguageIds { get; set; }
        public int? DocumentTypeId { get; set; } = null;
        public int? CheckType { get; set; } = 0;

        [Required(ErrorMessage = "Không nhận được file tải lên")]
        public IFormFile File { get; set; }
        public List<int> DigiOutputExtensions { get; set; }
        public List<int> ExtrOutputExtensions { get; set; }
    }
    public class DocumentBaseRequest
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Không nhận được file tải lên")]
        public IFormFile File { get; set; }    
    }
    public class ExtractionRequest : DocumentBaseRequest
    {
        public int? DocumentTypeId { get; set; } = null;
    }
    public class RecognitionRequest : DocumentBaseRequest
    {
    }

    public class DocumentTemporaryRequest
    {
        public int UserId { get; set; }
        public int Type { get; set; }
        public int DocumentTypeId { get; set; }
        public IFormFile File { get; set; }
        public string FileId { get; set; }
    }
    public class DocumentRequestMultiFiles
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Loại dịch vụ không được phép trống")]
        public List<int> Type { get; set; }
        public int? LanguageId { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? CheckType { get; set; } = 0;

        [Required(ErrorMessage = "Không nhận được file tải lên")]
        public List<IFormFile> Files { get; set; }
        public string OutputExtension { get; set; }
        public int? FromPage { get; set; } = 1;
        public int? ToPage { get; set; } = 0;
        public string Description { get; set; }
    }
    public class DocumentEstimate
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Loại dịch vụ không được phép trống")]
        public int Type { get; set; }
        public int? LanguageId { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? CheckType { get; set; } = 0;

        [Required(ErrorMessage = "Không nhận được file tải lên")]
        public IFormFile File { get; set; }
    }
    public class FileCompleted
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
        public string sFile { get; set; }
        //public HttpResponseMessage File { get; set; }
        //public IFormFile File { get; set; }
        public int? PageCount { get; set; }
        public int? FieldCount { get; set; }
    }
    public class DocumentResultModel
    {
        public int Id { get; set; }
        public bool IsSuccessed { get; set; }
        public string FileName { get; set; }
    }

    public class DocumentRequestModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Loại dịch vụ không được bỏ trống")]
        public int Type { get; set; }
        public List<int> LanguageIds { get; set; }
        public List<int> OutputExtensions { get; set; }
        public int? CheckType { get; set; } = 0;
        public int? FromPage { get; set; } = 1;
        public int? ToPage { get; set; } = 0;
        public List<int> FileTemporaryIds { get; set; }
    }
}
