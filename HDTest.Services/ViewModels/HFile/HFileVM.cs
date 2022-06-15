using HuceDocs.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.ViewModels
{
    public class HFileVM
    {
        public HFileVM() { }
        public HFileVM(HFile model)
        {
            Id = model.Id;
            DocumentId = model.DocumentId;
            FileName = model.FileName;
            FilePath = model.FilePath;
            FileExtension = model.FileExtension;
            Status = model.Status;
        }

        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public int Status { get; set; }

    }
}
