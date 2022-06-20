using System;
using System.Collections.Generic;
using System.Text;

namespace HuceDocs.Data.Models
{
    public class BANG_DIEM_TIENG_ANH : IEntity
    {
        public int Id { get; set; }
        public string TICKET_ID { get; set; }
        public string HUCEDOCS_TYPE { get; set; }
        public string USER_CREATE { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public DateTime UPDATE_DATE { get; set; }
        public int STATUS { get; set; }
        public string FULL_NAME { get; set; }
        public DateTime DOB { get; set; }
        public string MAJOR { get; set; }
        public string STUDENT_ID { get; set; }
        public string S_CLASS { get; set; }
        public string TRAINING_FORM { get; set; }
        public string GPA_10SCALE { get; set; }
        public string GPA_4SCALE { get; set; }
        public string TOTAL_CREDITS { get; set; }
        public string CLASSIFICATION { get; set; }
        public string MARK_TABLE { get; set; }

        public virtual OCR_Request OCR_Request { get; set; }
    }
}
