using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Models
{
    public class DON_XIN_NHAP_HOC : IEntity
    {
        public int Id { get; set; }
        public string TICKET_ID { get; set; }
        public string HUCEDOCS_TYPE { get; set; }
        public string USER_CREATE { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public int STATUS { get; set; }

        public string NGUOI_LAP_DON { get; set; }
        public string NGAY_SINH { get; set; }
        public string MSSV { get; set; }
        public string KHOA { get; set; }
        public string LOP { get; set; }
        public string NHAP_HOC_TU_KY { get; set; }
        public string SO_GIAY_PHEP { get; set; }
        public string NGAY_NGHI_THEO_GIAY_PHEP { get; set; }
        public string NGAY_KY { get; set; }

        public virtual OCR_Request OCR_Request { get; set; }

    }
}
