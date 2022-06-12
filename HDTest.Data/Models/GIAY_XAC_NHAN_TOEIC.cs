using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Models
{
    public class GIAY_XAC_NHAN_TOEIC : IEntity
    {
        public int Id { get; set; }
        public string TICKET_ID { get; set; }
        public string HUCEDOCS_TYPE { get; set; }
        public string USER_CREATE { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public int STATUS { get; set; }
        public string HO_TEN { get; set; }
        public DateTime NGAY_SINH { get; set; }
        public string MSSV { get; set; }
        public string LOP { get; set; }
        public string NGANH_HOC { get; set; }
        public string HE_DAO_TAO { get; set; }
        public string KHOA { get; set; }
        public string NDXN { get; set; }
        public string DIEM_THI { get; set; }
        public string DOT_THI { get; set; }
        public DateTime NGAY_XAC_NHAN { get; set; }

        public virtual OCR_Request OCR_Request { get; set; }
    }
}
