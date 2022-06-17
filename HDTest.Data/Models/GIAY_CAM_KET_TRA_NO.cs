using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Models
{
    public class GIAY_CAM_KET_TRA_NO : IEntity
    {
        public int Id { get; set; }
        public string TICKET_ID { get; set; }
        public string HUCEDOCS_TYPE { get; set; }
        public string USER_CREATE { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public int STATUS { get; set; }

        public string MAU_SO { get; set; }
        public string HO_TEN_SV { get; set; }
        public DateTime NGAY_SINH { get; set; }
        public string GIOI_TINH { get; set; }
        public string CMND { get; set; }
        public DateTime NGAY_CAP_CMND { get; set; }
        public string NOI_CAP { get; set; }
        public string LOP { get; set; }
        public string KHOA { get; set; }
        public string SO_THE_HSSV { get; set; }
        public string NIEN_KHOA { get; set; }
        public string LOAI_HINH_DAO_TAO { get; set; }
        public DateTime NGAY_NHAP_HOC { get; set; }
        public DateTime NGAY_RA_TRUONG { get; set; }
        public string MA_TRUONG { get; set; }
        public string NGUOI_DUNG_TEN { get; set; }
        public string DIA_CHI_NGUOI_DUNG_TEN { get; set; }
        public string NGAN_HANG_VAY_VON { get; set; }
        public string SO_TIEN_BANG_SO { get; set; }
        public string SO_TIEN_BANG_CHU { get; set; }
        public DateTime NGAY_KY { get; set; }

        public virtual OCR_Request OCR_Request { get; set; }
    }
}
