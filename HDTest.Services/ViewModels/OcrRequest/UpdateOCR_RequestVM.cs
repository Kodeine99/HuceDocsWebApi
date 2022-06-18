using HuceDocs.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.ViewModels.OcrRequest
{
    public class UpdateOCR_RequestVM
    {
        public UpdateOCR_RequestVM() { }
        public UpdateOCR_RequestVM(OCR_Request req)
        {
            Ticket_Id = req.Ticket_Id;
            JsonData = req.JsonData;
            UserId = req.UserId;
            DocumentId = req.DocumentId;
            CreateTime = req.CreateTime;
            Token = req.Token;
            VerifyLink = req.VerifyLink;
            OCR_Status_Code = req.OCR_Status_Code;
            
        }

        public string Ticket_Id { get; set; } = String.Empty;
        public string JsonData { get; set; } = String.Empty;
        public int UserId { get; set; }
        public int DocumentId { get; set; }
        public DateTime CreateTime { get; set; }
        public string Token { get; set; } = String.Empty;
        public string VerifyLink { get; set; } = String.Empty;
        public int OCR_Status_Code { get; set; }
    }
}
