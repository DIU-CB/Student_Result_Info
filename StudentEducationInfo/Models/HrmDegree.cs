using System;
using System.Collections.Generic;

#nullable disable

namespace StudentEducationInfo.Models
{
    public partial class HrmDegree
    {
        public HrmDegree()
        {
            HrmEducations = new HashSet<HrmEducation>();
        }

        public string Degree { get; set; }

        public virtual ICollection<HrmEducation> HrmEducations { get; set; }
    }
}
