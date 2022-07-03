using HuceDocs.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services.ViewModels.ChungTu
{
    public class ChungTuVM
    {
    }

    public class BANG_DIEM_TIENG_ANH_VM 
    {
        public BANG_DIEM_TIENG_ANH_VM() { }
        public BANG_DIEM_TIENG_ANH_VM(BANG_DIEM_TIENG_ANH model)
        {
            Id = model.Id;
            TICKET_ID = model.TICKET_ID;
            HUCEDOCS_TYPE = model.HUCEDOCS_TYPE;
            USER_CREATE = model.USER_CREATE;
            CREATE_DATE = model.CREATE_DATE;
            UPDATE_DATE = model.UPDATE_DATE;
            STATUS = model.STATUS;
            FULL_NAME = model.FULL_NAME;
            DOB = model.DOB;
            MAJOR = model.MAJOR;
            STUDENT_ID = model.STUDENT_ID;
            S_CLASS = model.S_CLASS;
            TRAINING_FORM = model.TRAINING_FORM;
            GPA_10SCALE = model.GPA_10SCALE;
            GPA_4SCALE = model.GPA_4SCALE;
            TOTAL_CREDITS = model.TOTAL_CREDITS;
            CLASSIFICATION = model.CLASSIFICATION;
            MARK_TABLE = model.MARK_TABLE;
        }
        public int Id { get; set; }
        public string TICKET_ID { get; set; }
        public string HUCEDOCS_TYPE { get; set; }
        public string USER_CREATE { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public int STATUS { get; set; }
        public string FULL_NAME { get; set; }
        public string DOB { get; set; }
        public string MAJOR { get; set; }
        public string STUDENT_ID { get; set; }
        public string S_CLASS { get; set; }
        public string TRAINING_FORM { get; set; }
        public string GPA_10SCALE { get; set; }
        public string GPA_4SCALE { get; set; }
        public string TOTAL_CREDITS { get; set; }
        public string CLASSIFICATION { get; set; }
        public string MARK_TABLE { get; set; }
    }

    public class BANG_DIEM_TIENG_ANH_Filter
    {
        public int? Id { get; set; }
        public string? TICKET_ID { get; set; }
        public string? USER_CREATE { get; set; }
        public DateTime? FROM_DATE { get; set; }
        public DateTime? TO_DATE { get; set; }
    }

    public class ChungTuBaseFilter
    {
        public int? Id { get; set; }
        public string? TICKET_ID { get; set; }
        public string? USER_CREATE { get; set; }
        public DateTime? FROM_DATE { get; set; }
        public DateTime? TO_DATE { get; set; }
    }

    public class DeleteChungTuRequest
    {
         public string STATUS { get; set; }
    }

    public class GIAY_XAC_NHAN_TOEIC_VM
    {
        public GIAY_XAC_NHAN_TOEIC_VM() { }
        public GIAY_XAC_NHAN_TOEIC_VM(GIAY_XAC_NHAN_TOEIC model)
        {
            Id = model.Id;
            TICKET_ID = model.TICKET_ID;
            HUCEDOCS_TYPE = model.HUCEDOCS_TYPE;
            USER_CREATE = model.USER_CREATE;
            CREATE_DATE = model.CREATE_DATE;
            UPDATE_DATE = model.UPDATE_DATE;
            STATUS = model.STATUS;
            HO_TEN = model.HO_TEN;
            NGAY_SINH = model.NGAY_SINH;
            MSSV = model.MSSV;
            LOP = model.LOP;
            NGANH_HOC = model.NGANH_HOC;
            HE_DAO_TAO = model.HE_DAO_TAO;
            KHOA = model.KHOA;
            DIEM_THI = model.DIEM_THI;
            DOT_THI = model.DOT_THI;
            NGAY_XAC_NHAN = model.NGAY_XAC_NHAN;
            NDXN = model.NDXN;

        }
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
        public string NGANH_HOC { get; set; }
        public string HE_DAO_TAO { get; set; }
        public string KHOA { get; set; }
        public string NDXN { get; set; }
        public string DIEM_THI { get; set; }
        public string DOT_THI { get; set; }
        public string NGAY_XAC_NHAN { get; set; }
    } 
    
    public class GIAY_CAM_KET_TRA_NO_VM 
    {
        public GIAY_CAM_KET_TRA_NO_VM() { }
        public GIAY_CAM_KET_TRA_NO_VM(GIAY_CAM_KET_TRA_NO model)
        {
            Id = model.Id;
            TICKET_ID = model.TICKET_ID;
            USER_CREATE = model.USER_CREATE;
            CREATE_DATE = model.CREATE_DATE;
            UPDATE_DATE = model.UPDATE_DATE;
            STATUS = model.STATUS;
            HUCEDOCS_TYPE = model.HUCEDOCS_TYPE;

            MAU_SO = model.MAU_SO;
            HO_TEN_SV = model.HO_TEN_SV;
            NGAY_SINH = model.NGAY_SINH;
            NGAY_CAP_CMND = model.NGAY_CAP_CMND;
            NOI_CAP = model.NOI_CAP;
            LOP = model.LOP;
            KHOA = model.KHOA;
            SO_THE_HSSV = model.SO_THE_HSSV;
            NIEN_KHOA = model.NIEN_KHOA;
            LOAI_HINH_DAO_TAO = model.LOAI_HINH_DAO_TAO;
            NGAY_NHAP_HOC = model.NGAY_NHAP_HOC;
            NGAY_RA_TRUONG = model.NGAY_RA_TRUONG;
            MA_TRUONG = model.MA_TRUONG;
            NGUOI_DUNG_TEN = model.NGUOI_DUNG_TEN;
            DIA_CHI_NGUOI_DUNG_TEN = model.DIA_CHI_NGUOI_DUNG_TEN;
            NGAN_HANG_VAY_VON = model.NGAN_HANG_VAY_VON;
            SO_TIEN_BANG_SO = model.SO_TIEN_BANG_SO;
            SO_TIEN_BANG_CHU = model.SO_TIEN_BANG_CHU;
            NGAY_KY = model.NGAY_KY;
            //HUCEDOCS_TYPE = model.OCR_Request.JsonData

        }
        public int Id { get; set; }
        public string TICKET_ID { get; set; }
        public string HUCEDOCS_TYPE { get; set; }
        public string USER_CREATE { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public int STATUS { get; set; }

        public string MAU_SO { get; set; }
        public string HO_TEN_SV { get; set; }
        public string NGAY_SINH { get; set; }
        public string GIOI_TINH { get; set; }
        public string CMND { get; set; }
        public string NGAY_CAP_CMND { get; set; }
        public string NOI_CAP { get; set; }
        public string LOP { get; set; }
        public string KHOA { get; set; }
        public string SO_THE_HSSV { get; set; }
        public string NIEN_KHOA { get; set; }
        public string LOAI_HINH_DAO_TAO { get; set; }
        public string NGAY_NHAP_HOC { get; set; }
        public string NGAY_RA_TRUONG { get; set; }
        public string MA_TRUONG { get; set; }
        public string NGUOI_DUNG_TEN { get; set; }
        public string DIA_CHI_NGUOI_DUNG_TEN { get; set; }
        public string NGAN_HANG_VAY_VON { get; set; }
        public string SO_TIEN_BANG_SO { get; set; }
        public string SO_TIEN_BANG_CHU { get; set; }
        public string NGAY_KY { get; set; }
    }

    public class CCCD_VM
    {
        public CCCD_VM() { }

        public CCCD_VM(CCCD model)
        {
            Id = model.Id;
            TICKET_ID = model.TICKET_ID;
            USER_CREATE = model.USER_CREATE;
            CREATE_DATE = model.CREATE_DATE;
            UPDATE_DATE = model.UPDATE_DATE;
            STATUS = model.STATUS;
            HUCEDOCS_TYPE = model.HUCEDOCS_TYPE;

            SO = model.SO;
            HO_VA_TEN = model.HO_VA_TEN;
            NGAY_SINH = model.NGAY_SINH;
            GIOI_TINH = model.GIOI_TINH;
            QUOC_TICH = model.QUOC_TICH;
            QUE_QUAN = model.QUE_QUAN;
            NOI_THUONG_TRU = model.NOI_THUONG_TRU;
            CO_GIA_TRI_DEN = model.CO_GIA_TRI_DEN;
            NGAY_CAP = model.NGAY_CAP;
            NGUOI_KY = model.NGUOI_KY;
        }

        public int Id { get; set; }
        public string TICKET_ID { get; set; }
        public string HUCEDOCS_TYPE { get; set; }
        public string USER_CREATE { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public int STATUS { get; set; }


        public string SO { get; set; }
        public string HO_VA_TEN { get; set; }
        public string NGAY_SINH { get; set; }
        public string GIOI_TINH { get; set; }
        public string QUOC_TICH { get; set; }
        public string QUE_QUAN { get; set; }
        public string NOI_THUONG_TRU { get; set; }
        public string CO_GIA_TRI_DEN { get; set; }
        public string NGAY_CAP { get; set; }
        public string NGUOI_KY { get; set; }
    }

    public class THE_SINH_VIEN_VM
    {
        public THE_SINH_VIEN_VM() { }

        public THE_SINH_VIEN_VM(THE_SINH_VIEN model)
        {
            Id = model.Id;
            TICKET_ID = model.TICKET_ID;
            USER_CREATE = model.USER_CREATE;
            CREATE_DATE = model.CREATE_DATE;
            UPDATE_DATE = model.UPDATE_DATE;
            STATUS = model.STATUS;
            HUCEDOCS_TYPE = model.HUCEDOCS_TYPE;

            HO_TEN = model.HO_TEN;
            NGAY_SINH = model.NGAY_SINH;
            MSSV = model.MSSV;
            LOP = model.LOP;
            KHOA = model.KHOA;
            HKTT = model.HKTT;
            EMAIL = model.EMAIL;
            KHOA_HOC = model.KHOA_HOC;
        }

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
    }

    public class GIAY_XAC_NHAN_VAY_VON_VM
    {
        public GIAY_XAC_NHAN_VAY_VON_VM() { }

        public GIAY_XAC_NHAN_VAY_VON_VM(GIAY_XAC_NHAN_VAY_VON model)
        {
            Id = model.Id;
            TICKET_ID = model.TICKET_ID;
            USER_CREATE = model.USER_CREATE;
            CREATE_DATE = model.CREATE_DATE;
            UPDATE_DATE = model.UPDATE_DATE;
            STATUS = model.STATUS;
            HUCEDOCS_TYPE = model.HUCEDOCS_TYPE;

            HO_TEN = model.HO_TEN;
            NGAY_SINH = model.NGAY_SINH;
            GIOI_TINH = model.GIOI_TINH;
            CMND = model.CMND;
            NGAY_CAP_CMND = model.NGAY_CAP_CMND;
            NOI_CAP = model.NOI_CAP;
            MA_TRUONG = model.MA_TRUONG;
            TEN_TRUONG = model.TEN_TRUONG;
            NGANH_HOC = model.NGANH_HOC;
            HE_DT = model.HE_DT;
            SO_KHOA = model.SO_KHOA;
            MSSV = model.MSSV;
            LOP = model.LOP;
            KHOA = model.KHOA;
            NGAY_NHAP_HOC = model.NGAY_NHAP_HOC;
            NGAY_RA_TRUONG = model.NGAY_RA_TRUONG;
            HOC_PHI_MOI_THANG = model.HOC_PHI_MOI_THANG;
            STK = model.STK;
            TAI_NH = model.TAI_NH;
            CM_THUOC_DIEN = model.CM_THUOC_DIEN;
            CM_THUOC_DOI_TUONG = model.CM_THUOC_DOI_TUONG;
        }

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
    }

    public class DON_XIN_NHAP_HOC_VM
    {
        public DON_XIN_NHAP_HOC_VM() { }

        public DON_XIN_NHAP_HOC_VM(DON_XIN_NHAP_HOC model)
        {
            Id = model.Id;
            TICKET_ID = model.TICKET_ID;
            USER_CREATE = model.USER_CREATE;
            CREATE_DATE = model.CREATE_DATE;
            UPDATE_DATE = model.UPDATE_DATE;
            STATUS = model.STATUS;
            HUCEDOCS_TYPE = model.HUCEDOCS_TYPE;

            NGUOI_LAP_DON = model.NGUOI_LAP_DON;
            NGAY_SINH = model.NGAY_SINH;
            MSSV = model.MSSV;
            LOP = model.LOP;
            KHOA = model.KHOA;
            NHAP_HOC_TU_KY = model.NHAP_HOC_TU_KY;
            SO_GIAY_PHEP = model.SO_GIAY_PHEP;
            NGAY_NGHI_THEO_GIAY_PHEP = model.NGAY_NGHI_THEO_GIAY_PHEP;
            NGAY_KY = model.NGAY_KY;
        }

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
    }
}
