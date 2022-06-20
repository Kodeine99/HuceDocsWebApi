using HuceDocs.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuceDocs.Services.ViewModels.OcrRequest
{
    public class OCR_RequestVM
    {

        public OCR_RequestVM() { }
        public OCR_RequestVM(OCR_Request model)
        {
            Id = model.Id;
            Ticket_Id = model.Ticket_Id;
            JsonData = model.JsonData;
            DocumentId = model.DocumentId;
            UserId = model.UserId;
            CreateTime = model.CreateTime;
            Token = model.Token;
            OCR_Status_Code = model.OCR_Status_Code;
            VerifyLink = model.VerifyLink;
            Username = model.User?.UserName;
            HFiles = model.Document?.HFiles.Select(o => new HFileVM(o)).ToList();

            
        }
        public int Id { get; set; }
        public string Ticket_Id { get; set; } = String.Empty;
        public string JsonData { get; set; } = String.Empty;
        public int? DocumentId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateTime { get; set; }
        public string Token { get; set; } = String.Empty;
        public int OCR_Status_Code { get; set; }
        public string VerifyLink { get; set; }
        public string Username { get; set; }
        public List<HFileVM> HFiles { get; set; }
    }

    public class OCR_RequestFilter
    {
        public int? Id { get; set; }
        public string Ticket_Id { get; set; } = String.Empty;
        public int? DocumentId { get; set; }
        public int? UserId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? OCR_Status_Code { get; set; }
    }
}
