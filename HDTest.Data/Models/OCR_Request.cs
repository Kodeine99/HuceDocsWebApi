using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuceDocs.Data.Models
{
    public class OCR_Request : IEntity
    {
        public int Id { get; set; }
        public string Ticket_Id { get; set; } = String.Empty;
        public string JsonData { get; set; } = String.Empty;
        public int? DocumentId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateTime { get; set; }
        public string Token { get; set; } = String.Empty;
        public int OCR_Status_Code { get; set; }
        public string VerifyLink { get; set; } 
        public virtual User User { get; set; }

        public virtual Document Document { get; set; }

        public ICollection<GIAY_XAC_NHAN_TOEIC> GIAY_XAC_NHAN_TOEICs { get; set; }
        public ICollection<GIAY_CAM_KET_TRA_NO> GIAY_CAM_KET_TRA_NOs { get; set; }

    }
}
