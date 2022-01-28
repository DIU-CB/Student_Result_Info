using System;
using System.Collections.Generic;

#nullable disable

namespace StudentEducationInfo.Models
{
    public partial class HrmEducation
    {
        public long PersonId { get; set; }
        public string Degree { get; set; }
        public string MajorSubject { get; set; }
        public string Institute { get; set; }
        public string UniversityBoard { get; set; }
        public string ControlledBy { get; set; }
        public short? PassingYear { get; set; }
        public string Result { get; set; }
        public string Remarks { get; set; }
        public decimal? Cgpa { get; set; }
        public int? FkEducationalInstitute { get; set; }
        public bool? StudentUpdate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }

        public virtual HrmDegree DegreeNavigation { get; set; }
        public virtual HrmPerson Person { get; set; }
    }
}
