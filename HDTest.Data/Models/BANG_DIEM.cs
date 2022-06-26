using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Models
{
    public class BANG_DIEM : IEntity
    {
        public int Id { get; set; }
        public string TICKET_ID { get; set; }
        public string HUCEDOCS_TYPE { get; set; }
        public string USER_CREATE { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public int STATUS { get; set; }

        public string HO_TEN { get; set; }
        public string MSSV { get; set; }
        public string NGAY_SINH { get; set; }
        public string LOP { get; set; }
        public string NGANH { get; set; }
        public string HE_DAO_TAO { get; set; }
        public string THANG_DIEM_10 { get; set; }
        public string THANG_DIEM_4 { get; set; }
        public string TONG_SO_TIN_CHI { get; set; }
        public string MARK_TABLE { get; set; }


        public virtual OCR_Request OCR_Request { get; set; }

    }
}
