using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Models
{
    public class CCCD : IEntity
    {

        public int Id { get; set; }
        public string TICKET_ID { get; set; }
        public string HUCEDOCS_TYPE { get; set; }
        public string USER_CREATE { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public int STATUS { get; set; }


        public string HO_TEN { get; set; }
        public string SO_THE { get; set; }
        public string NGAY_SINH { get; set; }
        public string GIOI_TINH { get; set; }
        public string QUOC_TICH { get; set; }
        public string QUE_QUAN { get; set; }
        public string DIA_CHI_THUONG_TRU { get; set; }
        public string NGAY_CAP { get; set; }

        public virtual OCR_Request OCR_Request { get; set; }

    }
}
