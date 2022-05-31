using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HuceDocs.Services.EnumDefine
{
    public enum eDocumentType
    {
        [Description("Số hóa")]
        Digitization = 0,
        [Description("Bóc tách")]
        Extraction = 1,
    }

    public enum eDocumentStatus
    {
        [Description("Chở xử lý")]
        Prepare = 0,
        [Description("Đang xử lý")]
        Processing = 1,
        [Description("Hoàn thành")]
        Complete = 2,
        [Description("Không thành công")]
        Failure = 3,
        [Description("Đang soát lỗi")]
        Verify = 4,

        [Description("Không đủ tiền")]
        NotEnoughMoney = 100,
        [Description("Lỗi nhận dạng")]
        ErrorRead = 101,
    }

    public enum ePaymentType
    {
        [Description("Momo")]
        momo = 1,
        [Description("vnpay")]
        vnpay = 2
    }

    public enum ePaymentStatus
    {
        [Description("Chờ thanh toán")]
        wait = 0,
        [Description("Đã thanh toán")]
        done = 1,
        [Description("Không thành công")]
        fail = 2
    }

    public enum eFolder
    {
        input = 0,
        ouput = 1
    }

    public enum eStatus
    {
        [Description("Hoạt động")]
        active = 1,
        [Description("Không hoạt động")]
        deactive = 0,
        [Description("Bị khóa")]
        locked = 2
    }

    public enum eUserClass
    {
        [Description("Tài khoản thường")]
        normal = 0,
        [Description("Tài khoản doanh nghiệp")]
        master = 1,
        [Description("Tài khoản nhân viên - doanh nghiệp")]
        employer = 2
    }

    public enum eDocumentCheckType
    {
        [Description("Soát lỗi tự động")]
        auto = 0,
        [Description("Soát lỗi thủ công")]
        manual = 1
    }

    public enum eDocumentPayment
    {
        [Description("Tính tiền theo loại văn bản")]
        Type = 0,
        [Description("Tính tiền theo số trang")]
        Page = 1,
        [Description("Tính tiền theo số trường")]
        Field = 2
    }

    public enum eTypeOfResult
    {
        [Description("Kết quả đầu ra chỉ có file xlsx")]
        OnlyXlsx = 1
    }

    public enum eTokenType
    {
        [Description("Token đăng nhập bình thường")]
        Normal = 1,
        [Description("Token genarate for api")]
        ForApi = 2
    }
    public enum eNotifyStatus
    {
        [Description("thành công")]
        success = 1,
        [Description("không thành công")]
        failure = 0
    }
    public enum eStatusCode
    {
        [Description("Thành công")]
        Success = 1,
        [Description("Lưu thành công")]
        SaveSuccess = 11,
        [Description("Thất bại")]
        Failure = 0,
        [Description("Lưu thành công")]
        SaveFailure = 10,
        [Description("Đăng nhập thành công")]
        LoginSuccess = 1000,
        [Description("Đăng nhập không thành công")]
        LoginFail = 1001,
        [Description("Tài khoản không tồn tại")]
        DoNotExist = 1002,
        [Description("Tài khoản đã bị khóa")]
        Locked = 1003,
        [Description("Người dùng cần xác nhận địa chỉ email trước khi đăng nhập.")]
        EmailNotConfirmed = 1004,
        [Description("Đăng nhập tài khoản hoặc mật khẩu không đúng")]
        Wrong = 1005,
        [Description("Đăng ký thành công")]
        RegisterSuccess = 1100,
        [Description("Đăng ký không thành công")]
        RegisterFailure = 1101,
        [Description("Emai đã tồn tại")]
        EmailAlreadyExist = 1102,
        [Description("Mật khẩu yêu cầu chưa ít nhất 1 chữ hoa, 1 chữ thường và số")]
        PasswordRequire = 1103,
        [Description("Email không hợp lệ")]
        UserNameRequire = 1104,
        [Description("Đổi mật khẩu thành công")]
        ChangePaswordSuccess = 1200,
        [Description("Đổi mật khẩu không thành công")]
        ChangePaswordFail = 1201,
        [Description("Mật khẩu xác nhận không khớp")]
        PassNotSimilar = 1202,
        [Description("Mật khẩu hiện tại không chính xác")]
        PassWrong = 1203
    }
    public static class eGet
    {
        public static string Status(int? key)
        {
            switch (key)
            {
                case (int)eDocumentStatus.Prepare: return "Chở xử lý";
                case (int)eDocumentStatus.Processing: return "Đang xử lý";
                case (int)eDocumentStatus.Complete: return "Hoàn thành";
                case (int)eDocumentStatus.Failure: return "Không thành công";
                case (int)eDocumentStatus.Verify: return "Đang soát lỗi";
                case (int)eDocumentStatus.NotEnoughMoney: return "Không đủ tiền";
                case (int)eDocumentStatus.ErrorRead: return "Lỗi";
                default:
                    return "Không xác định";
            }
        }
        public static string TypeOfDocument(int key)
        {
            switch (key)
            {
                case (int)eDocumentType.Digitization: return "Số hóa";
                case (int)eDocumentType.Extraction: return "Bóc tách";
                default:
                    return null;
            }
        }
        public static string TypeOfPayment(int key)
        {
            switch (key)
            {
                case (int)ePaymentType.momo: return "momo";
                case (int)ePaymentType.vnpay: return "vnpay";
                default:
                    return "Không xác định";
            }
        }
        public static List<int> ListClassId()
        {
            var result = new List<int>();
            result.Add((int)eUserClass.normal);
            result.Add((int)eUserClass.master);
            result.Add((int)eUserClass.employer);
            return result;
        }
        public static List<int> ListTypeOfDocument()
        {
            var result = new List<int>();
            result.Add((int)eDocumentType.Digitization);
            result.Add((int)eDocumentType.Extraction);
            return result;
        }
        public static List<int> ListCheckType()
        {
            var result = new List<int>();
            result.Add((int)eDocumentCheckType.auto);
            result.Add((int)eDocumentCheckType.manual);
            return result;
        }
    }

}
