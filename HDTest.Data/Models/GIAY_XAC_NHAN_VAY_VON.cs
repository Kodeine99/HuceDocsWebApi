using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Models
{
    public  class GIAY_XAC_NHAN_VAY_VON : IEntity
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
        public string GIOI_TINH { get; set; }
        public string CMND { get; set; }
        public string NGAY_CAP_CMND { get; set; }
        public string NOI_CAP { get; set; }
        public string MA_TRUONG { get; set; }
        public string TEN_TRUONG { get; set; }
        public string NGANH_HOC { get; set; }
        public string HE_DT { get; set; }
        public string SO_KHOA { get; set; }
        public string LOP { get; set; }
        public string MSSV { get; set; }
        public string KHOA { get; set; }
        public string NGAY_NHAP_HOC { get; set; }
        public string NGAY_RA_TRUONG { get; set; }
        public string HOC_PHI_MOI_THANG { get; set; }
        public string STK { get; set; }
        public string TAI_NH { get; set; }
        public string CM_THUOC_DIEN { get; set; }
        public string CM_THUOC_DOI_TUONG { get; set; }

        public virtual OCR_Request OCR_Request { get; set; }


    }
}
