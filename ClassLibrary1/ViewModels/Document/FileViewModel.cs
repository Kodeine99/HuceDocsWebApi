using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.ViewModels.Document
{
    public class FileViewModel
    {
        public string FileData { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public bool isExtrResult { get; set; }
    }

    public class FileTemporaryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
        public int? Pages { get; set; }
        public int Status { get; set; }
        public double? Amount { get; set; }
        public string FileId { get; set; }
        public int DocId { get; set; }
    }
}
