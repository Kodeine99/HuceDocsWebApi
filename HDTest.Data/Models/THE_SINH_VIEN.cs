using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Models
{
    public class THE_SINH_VIEN : IEntity
    {
        public int Id { get; set; }
        public string TICKET_ID { get; set; }
        public string HUCEDOCS_TYPE { get; set; }
        public string USER_CREATE { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public int STATUS { get; set; }


        public string HO_TEN { get; set; }
        public string NGAY_SINH { get; set; }
        public string MSSV { get; set; }
        public string LOP { get; set; }
        public string KHOA { get; set; }
        public string HKTT { get; set; }
        public string EMAIL { get; set; }
        public string KHOA_HOC { get; set; }

        public virtual OCR_Request OCR_Request { get; set; }

    }
}
