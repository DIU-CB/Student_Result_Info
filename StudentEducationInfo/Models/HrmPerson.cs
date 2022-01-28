using System;
using System.Collections.Generic;

#nullable disable

namespace StudentEducationInfo.Models
{
    public partial class HrmPerson
    {
        public HrmPerson()
        {
            HrmEducations = new HashSet<HrmEducation>();
            SmisStudents = new HashSet<SmisStudent>();
        }

        public long PersonId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Sex { get; set; }
        public string BloodGroup { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Religion { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AuthCodePassword { get; set; }
        public string Im { get; set; }
        public string Mobile { get; set; }
        public string PresentHouse { get; set; }
        public string PresentStreet { get; set; }
        public string PresentCity { get; set; }
        public int? PreDisId { get; set; }
        public string PresentDistrict { get; set; }
        public string PresentCountry { get; set; }
        public string PresentZipCode { get; set; }
        public string PresentPhone { get; set; }
        public string PermanentHouse { get; set; }
        public string PermanentStreet { get; set; }
        public string PermanentCity { get; set; }
        public int? PerDisId { get; set; }
        public string PermanentDistrict { get; set; }
        public string PermanentCountry { get; set; }
        public string PermanentZipCode { get; set; }
        public string PermanentPhone { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string MaritalStatus { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoFile { get; set; }
        public byte[] Signature { get; set; }
        public string SignatureFile { get; set; }
        public string PersonType { get; set; }
        public string PassportNo { get; set; }
        public string Nationality { get; set; }
        public string VoterId { get; set; }
        public string Tin { get; set; }
        public string Notes { get; set; }
        public string InitialPassword { get; set; }
        public string WorkPhone { get; set; }
        public int? StuEnabled { get; set; }
        public string StuDisabledMsg { get; set; }
        public int? EmpEnabled { get; set; }
        public string EmpDisabledMsg { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string LastLoginStudentId { get; set; }
        public string AppName { get; set; }
        public string PlaceOfBirth { get; set; }
        public string SocialNetId { get; set; }
        public string FatherMobile { get; set; }
        public string FatherOccupation { get; set; }
        public string FatherDesignation { get; set; }
        public string FatherEmployerName { get; set; }
        public decimal? FatherAnnualIncome { get; set; }
        public string MotherMobile { get; set; }
        public string MotherOccupation { get; set; }
        public string MotherDesignation { get; set; }
        public string MotherEmployerName { get; set; }
        public decimal? MotherAnnualIncome { get; set; }
        public string ParentAddress { get; set; }
        public string LocalGuardianName { get; set; }
        public string LocalGuardianMobile { get; set; }
        public string LocalGuardianRelation { get; set; }
        public string LocalGuardianAddress { get; set; }
        public string BearEduExpense { get; set; }
        public string PrePostOffice { get; set; }
        public string PrePoliceStation { get; set; }
        public string PerPostOffice { get; set; }
        public string PerPoliceStation { get; set; }
        public string EmailAlternative { get; set; }
        public string HostelAddress { get; set; }
        public string MessAddress { get; set; }
        public string OtherAddress { get; set; }
        public bool? TransparentTeacher { get; set; }
        public string VideoCvLink { get; set; }
        public string GoogleSiteLink { get; set; }

        public virtual ICollection<HrmEducation> HrmEducations { get; set; }
        public virtual ICollection<SmisStudent> SmisStudents { get; set; }
    }
}
