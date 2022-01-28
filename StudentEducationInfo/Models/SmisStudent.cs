using System;
using System.Collections.Generic;

#nullable disable

namespace StudentEducationInfo.Models
{
    public partial class SmisStudent
    {
        public SmisStudent()
        {
            InverseFkStudentIdOfRelativeNavigation = new HashSet<SmisStudent>();
            InverseTransfer = new HashSet<SmisStudent>();
        }

        public string StudentId { get; set; }
        public long PersonId { get; set; }
        public string BatchId { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string LastSemester { get; set; }
        public string DropCause { get; set; }
        public float? TotalMarks { get; set; }
        public float? GradePoints { get; set; }
        public string GradeLetter { get; set; }
        public string DocLoc { get; set; }
        public string Reference { get; set; }
        public int? PaymentScheme { get; set; }
        public string Shift { get; set; }
        public string TransferId { get; set; }
        public int? ProgramCredit { get; set; }
        public int? ExemptedCredit { get; set; }
        public int? NetCredit { get; set; }
        public decimal? SscCgpa { get; set; }
        public decimal? HscCgpa { get; set; }
        public decimal? GraduationCgpa { get; set; }
        public decimal? MastersCgpa { get; set; }
        public string GoldenGpa { get; set; }
        public string CommentsAcc { get; set; }
        public string InitialPassword { get; set; }
        public string SecurityCode { get; set; }
        public string FkCampus { get; set; }
        public string Laptop { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? FkPassingDiscipline { get; set; }
        public string FkStudentIdOfRelative { get; set; }
        public string Blocked { get; set; }
        public string AdmissionFromSlno { get; set; }
        public string PassOutSemester { get; set; }
        public string LastSemesterRemarks { get; set; }
        public DateTime? PassOutDate { get; set; }
        public int? FkConvocation { get; set; }
        public string BlockCause { get; set; }
        public string BrifDescription { get; set; }
        public string PersonalInterest { get; set; }
        public string InitialProblem { get; set; }
        public string StrangthOfStudent { get; set; }
        public string WeaknessOfStudent { get; set; }
        public string AdditionalInfoOfStudent { get; set; }
        public bool? ExDiu { get; set; }
        public int? FkAdmissionReferenceDetails { get; set; }
        public string AdmReferenceName { get; set; }

        public virtual SmisStudent FkStudentIdOfRelativeNavigation { get; set; }
        public virtual SmisSemester LastSemesterNavigation { get; set; }
        public virtual SmisSemester PassOutSemesterNavigation { get; set; }
        public virtual HrmPerson Person { get; set; }
        public virtual SmisStudent Transfer { get; set; }
        public virtual ICollection<SmisStudent> InverseFkStudentIdOfRelativeNavigation { get; set; }
        public virtual ICollection<SmisStudent> InverseTransfer { get; set; }
    }
}
