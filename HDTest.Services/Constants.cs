using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Services
{
    internal class Constants
    {
        public static string ECM_ERR = "ECM_ERR";
        public static string OCR_ERR = "OCR_ERR";
        public static string OK = "OK";

        public static string TokenInvalid = "InvalidToken";
        public static string InvalidPassword = "InvalidPassword";
    }

    public static class EcmType
    {
        public const string TheSinhVien = "THE_SINH_VIEN";
        public const string CCCD = "CCCD";
        public const string BangDiemTiengAnh = "BANG_DIEM_TIENG_ANH";
        public const string GiayCamKetTraNo = "GIAY_CAM_KET_TRA_NO";
        public const string BangDiem = "BANG_DIEM";
        public const string GiayXacNhanToeic = "GIAY_XAC_NHAN_TOEIC";
        public const string GiayXacNhanVayVon = "GIAY_XAC_NHAN_VAY_VON";


    }

    public static class BatchType
    {
        public const string HuceDocs = "HuceDocs";
        public const string TheSinhVien = "TheSinhVien";
        public const string CCCD = "CanCuocCongDan";
        public const string GiayXacNhanToeic = "GiayXacNhanToeic";
        public const string GiayCamKetTraNo = "GiayCamKetTraNo";
        public const string BangDiemTiengAnh = "BangDiemTiengAnh";
        public const string BangDiem = "BangDiem";
        public const string GiayXacNhanVayVon = "GiayXacNhanVayVon";

    }

    public static class StageType
    {
        public const int Script = 260;
        public const int Recognition = 200;
        public const int Exception = 1000;
        public const int Processed = 900;
        public const int Export = 800;
        public const int Verification = 500;
    }

    public static class StageName
    {
        public const string Exception = "Exception";
        public const string Recognize = "Recognize";
        public const string ExportWithOutVerify = "Export WithOut Verify";
        public const string ExportWithVerify = "Export With Verified";
        public const string Verification = "Verification";
        public const string Processed = "Processed";

        public static string GetCode(string stageName)
        {
            switch (stageName)
            {
                case Exception: return "1000"; //loi
                case Recognize: return "200"; // Dang OCR
                case ExportWithOutVerify: return "269"; // Update Link
                case ExportWithVerify: return "1000"; // Update data
                case Verification: return "1000"; // Soat loi
                case Processed: return "1000"; // Done
                default:
                    return "1000";
            }
        }
    }
}
