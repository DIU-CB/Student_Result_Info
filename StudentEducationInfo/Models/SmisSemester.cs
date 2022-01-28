using System;
using System.Collections.Generic;

#nullable disable

namespace StudentEducationInfo.Models
{
    public partial class SmisSemester
    {
        public SmisSemester()
        {
            SmisStudentLastSemesterNavigations = new HashSet<SmisStudent>();
            SmisStudentPassOutSemesterNavigations = new HashSet<SmisStudent>();
        }

        public string SemesterId { get; set; }
        public short SemesterNo { get; set; }
        public short SemesterYear { get; set; }
        public string CurrentSemester { get; set; }

        public virtual ICollection<SmisStudent> SmisStudentLastSemesterNavigations { get; set; }
        public virtual ICollection<SmisStudent> SmisStudentPassOutSemesterNavigations { get; set; }
    }
}
