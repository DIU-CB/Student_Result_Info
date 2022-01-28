using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEducationInfo.Models
{
    public class StudentEducationModel
    {
        public string StudentID { get; set; }
        public long PersonID { get; set; }

        
        public string Degree { get; set; }
        public string MajorSubject { get; set; }
        public string Institute { get; set; }
        public string Board { get; set; }
        public short? PassingYear { get; set; }
        public decimal? CGPA { get; set; }
    
    }
}
