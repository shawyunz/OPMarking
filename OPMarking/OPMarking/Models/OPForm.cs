using System;
using System.Collections.Generic;

namespace OPMarking.Models
{
    public class OPForm
    {
        public string Id { get; set; }
        public string LectureId { get; set; }
        public string LecturerName { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string OPFormDate { get; set; }
        public int MarkObtain { get; set; }
        public int MarkTotal { get; set; }
        public int MarkScale { get; set; }
        public List<OPFormLine> Lines { get; set; }
    }
}