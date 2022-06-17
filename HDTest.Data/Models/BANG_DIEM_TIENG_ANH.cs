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
        public int FULL_NAME { get; set; }
        public DateTime DOB { get; set; }
        public int MAJOR { get; set; }
        public int STUDENT_ID { get; set; }
        public int S_CLASS { get; set; }
        public int TRAINING_FORM { get; set; }
        public int GPA_10SCALE { get; set; }
        public int GPA_4SCALE { get; set; }
        public int TOTAL_CREDITS { get; set; }
        public int CLASSIFICATION { get; set; }
        public string MARK_TABLE { get; set; }
    }
}
