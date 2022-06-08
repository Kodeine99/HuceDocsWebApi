using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.ViewModels.OcrRequest
{
    public class Request
    {
        public string TicketID { get; set; }
        public string User { get; set; }
        public List<ECM> EcmID_List { get; set; }
    }

    public class ECM
    {
        public string EcmID { get; set; }
        public string Type { get; set; }
    }

    /// <summary>
    /// Model used for create job OCR
    /// </summary>
    
}
