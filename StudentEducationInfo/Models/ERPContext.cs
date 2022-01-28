using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StudentEducationInfo.Models
{
    public partial class ERPContext : DbContext
    {
        public ERPContext()
        {
        }

        public ERPContext(DbContextOptions<ERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HrmDegree> HrmDegrees { get; set; }
        public virtual DbSet<HrmEducation> HrmEducations { get; set; }
        public virtual DbSet<HrmPerson> HrmPeople { get; set; }
        public virtual DbSet<SmisSemester> SmisSemesters { get; set; }
        public virtual DbSet<SmisStudent> SmisStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=192.168.10.124\\SQLEXPRESS;User Id=sa;Password=Start777;database=ERP");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<HrmDegree>(entity =>
            {
                entity.HasKey(e => e.Degree);

                entity.ToTable("HRM_DEGREE");

                entity.Property(e => e.Degree)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE");
            });

            modelBuilder.Entity<HrmEducation>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.Degree, e.MajorSubject });

                entity.ToTable("HRM_EDUCATION");

                entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");

                entity.Property(e => e.Degree)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEGREE");

                entity.Property(e => e.MajorSubject)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MAJOR_SUBJECT");

                entity.Property(e => e.Cgpa)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("cgpa");

                entity.Property(e => e.ControlledBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTROLLED_BY");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkEducationalInstitute).HasColumnName("FK_EDUCATIONAL_INSTITUTE");

                entity.Property(e => e.Institute)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("INSTITUTE");

                entity.Property(e => e.PassingYear).HasColumnName("PASSING_YEAR");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.Result)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESULT");

                entity.Property(e => e.StudentUpdate)
                    .HasColumnName("STUDENT_UPDATE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UniversityBoard)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UNIVERSITY_BOARD");

                entity.HasOne(d => d.DegreeNavigation)
                    .WithMany(p => p.HrmEducations)
                    .HasForeignKey(d => d.Degree)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HRM_EDUCATION_HRM_DEGREE");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.HrmEducations)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_HRM_EDUCATION_HRM_PERSON");
            });

            modelBuilder.Entity<HrmPerson>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK_person");

                entity.ToTable("HRM_PERSON");

                entity.HasIndex(e => e.BloodGroup, "IX_HRM_PERSON_BLOOD");

                entity.HasIndex(e => e.Email, "IX_HRM_PERSON_EMAIL");

                entity.HasIndex(e => e.Mobile, "IX_HRM_PERSON_MOBILE");

                entity.HasIndex(e => e.Sex, "IX_HRM_PERSON_SEX");

                entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");

                entity.Property(e => e.AppName)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("APP_NAME");

                entity.Property(e => e.AuthCodePassword)
                    .HasMaxLength(150)
                    .HasColumnName("AUTH_CODE_PASSWORD");

                entity.Property(e => e.BearEduExpense)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("bearEduExpense");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("BIRTH_DATE");

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BLOOD_GROUP");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.EmailAlternative)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailAlternative");

                entity.Property(e => e.EmpDisabledMsg)
                    .HasMaxLength(150)
                    .HasColumnName("EMP_DISABLED_MSG");

                entity.Property(e => e.EmpEnabled)
                    .HasColumnName("EMP_ENABLED")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FatherAnnualIncome)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("fatherAnnualIncome");

                entity.Property(e => e.FatherDesignation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fatherDesignation");

                entity.Property(e => e.FatherEmployerName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fatherEmployerName");

                entity.Property(e => e.FatherMobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("fatherMobile");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FATHER_NAME");

                entity.Property(e => e.FatherOccupation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fatherOccupation");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.GoogleSiteLink)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("GOOGLE_SITE_LINK");

                entity.Property(e => e.HostelAddress)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("hostelAddress");

                entity.Property(e => e.Im)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IM");

                entity.Property(e => e.InitialPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("INITIAL_PASSWORD");

                entity.Property(e => e.LastLoginStudentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_LOGIN_STUDENT_ID");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.LocalGuardianAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("localGuardianAddress");

                entity.Property(e => e.LocalGuardianMobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("localGuardianMobile");

                entity.Property(e => e.LocalGuardianName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("localGuardianName");

                entity.Property(e => e.LocalGuardianRelation)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("localGuardianRelation");

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MARITAL_STATUS");

                entity.Property(e => e.MessAddress)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("messAddress");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE");

                entity.Property(e => e.MotherAnnualIncome)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("motherAnnualIncome");

                entity.Property(e => e.MotherDesignation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("motherDesignation");

                entity.Property(e => e.MotherEmployerName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("motherEmployerName");

                entity.Property(e => e.MotherMobile)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("motherMobile");

                entity.Property(e => e.MotherName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOTHER_NAME");

                entity.Property(e => e.MotherOccupation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("motherOccupation");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(50)
                    .HasColumnName("NATIONALITY");

                entity.Property(e => e.NickName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NICK_NAME");

                entity.Property(e => e.Notes)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("NOTES");

                entity.Property(e => e.OtherAddress)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("otherAddress");

                entity.Property(e => e.ParentAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("parentAddress");

                entity.Property(e => e.PassportNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSPORT_NO");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PerDisId).HasColumnName("PER_DIS_ID");

                entity.Property(e => e.PerPoliceStation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("perPoliceStation");

                entity.Property(e => e.PerPostOffice)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("perPostOffice");

                entity.Property(e => e.PermanentCity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERMANENT_CITY");

                entity.Property(e => e.PermanentCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERMANENT_COUNTRY");

                entity.Property(e => e.PermanentDistrict)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERMANENT_DISTRICT");

                entity.Property(e => e.PermanentHouse)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PERMANENT_HOUSE");

                entity.Property(e => e.PermanentPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERMANENT_PHONE");

                entity.Property(e => e.PermanentStreet)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PERMANENT_STREET");

                entity.Property(e => e.PermanentZipCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERMANENT_ZIP_CODE");

                entity.Property(e => e.PersonType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PERSON_TYPE");

                entity.Property(e => e.Photo)
                    .HasColumnType("image")
                    .HasColumnName("PHOTO");

                entity.Property(e => e.PhotoFile)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PHOTO_FILE");

                entity.Property(e => e.PlaceOfBirth)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("placeOfBirth");

                entity.Property(e => e.PreDisId).HasColumnName("PRE_DIS_ID");

                entity.Property(e => e.PrePoliceStation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrePostOffice)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("prePostOffice");

                entity.Property(e => e.PresentCity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRESENT_CITY");

                entity.Property(e => e.PresentCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRESENT_COUNTRY");

                entity.Property(e => e.PresentDistrict)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRESENT_DISTRICT");

                entity.Property(e => e.PresentHouse)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRESENT_HOUSE");

                entity.Property(e => e.PresentPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRESENT_PHONE");

                entity.Property(e => e.PresentStreet)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRESENT_STREET");

                entity.Property(e => e.PresentZipCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRESENT_ZIP_CODE");

                entity.Property(e => e.Religion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RELIGION");

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SEX");

                entity.Property(e => e.Signature)
                    .HasColumnType("image")
                    .HasColumnName("SIGNATURE");

                entity.Property(e => e.SignatureFile)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SIGNATURE_FILE");

                entity.Property(e => e.SocialNetId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("socialNetId");

                entity.Property(e => e.StuDisabledMsg)
                    .HasMaxLength(150)
                    .HasColumnName("STU_DISABLED_MSG");

                entity.Property(e => e.StuEnabled)
                    .HasColumnName("STU_ENABLED")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Tin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIN");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.TransparentTeacher).HasColumnName("transparentTeacher");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_TIME");

                entity.Property(e => e.VideoCvLink)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("VIDEO_CV_LINK");

                entity.Property(e => e.VoterId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VOTER_ID");

                entity.Property(e => e.WorkPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WORK_PHONE");
            });

            modelBuilder.Entity<SmisSemester>(entity =>
            {
                entity.HasKey(e => e.SemesterId)
                    .HasName("PK_semester_1");

                entity.ToTable("SMIS_SEMESTER");

                entity.Property(e => e.SemesterId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SEMESTER_ID");

                entity.Property(e => e.CurrentSemester)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CURRENT_SEMESTER")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SemesterNo).HasColumnName("SEMESTER_NO");

                entity.Property(e => e.SemesterYear).HasColumnName("SEMESTER_YEAR");
            });

            modelBuilder.Entity<SmisStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__student__7F60ED59");

                entity.ToTable("SMIS_STUDENT");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STUDENT_ID");

                entity.Property(e => e.AdditionalInfoOfStudent)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("additionalInfoOfStudent");

                entity.Property(e => e.AdmReferenceName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ADM_REFERENCE_NAME");

                entity.Property(e => e.AdmissionFromSlno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADMISSION_FROM_SLNO");

                entity.Property(e => e.BatchId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BATCH_ID");

                entity.Property(e => e.BlockCause)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("BLOCK_CAUSE");

                entity.Property(e => e.Blocked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("BLOCKED")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.BrifDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("brifDescription");

                entity.Property(e => e.CommentsAcc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS_ACC");

                entity.Property(e => e.CompletionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETION_DATE");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_TIME")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DocLoc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DOC_LOC");

                entity.Property(e => e.DropCause)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DROP_CAUSE");

                entity.Property(e => e.EnrollmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENROLLMENT_DATE");

                entity.Property(e => e.ExDiu)
                    .HasColumnName("EX_DIU")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExemptedCredit)
                    .HasColumnName("EXEMPTED_CREDIT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExpireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRE_DATE");

                entity.Property(e => e.FkAdmissionReferenceDetails).HasColumnName("FK_ADMISSION_REFERENCE_DETAILS");

                entity.Property(e => e.FkCampus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FK_CAMPUS");

                entity.Property(e => e.FkConvocation).HasColumnName("FK_CONVOCATION");

                entity.Property(e => e.FkPassingDiscipline).HasColumnName("FK_PASSING_DISCIPLINE");

                entity.Property(e => e.FkStudentIdOfRelative)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FK_STUDENT_ID_OF_RELATIVE");

                entity.Property(e => e.GoldenGpa)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GOLDEN_GPA");

                entity.Property(e => e.GradeLetter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GRADE_LETTER");

                entity.Property(e => e.GradePoints).HasColumnName("GRADE_POINTS");

                entity.Property(e => e.GraduationCgpa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("GRADUATION_CGPA")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.HscCgpa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("HSC_CGPA")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.InitialPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("INITIAL_PASSWORD");

                entity.Property(e => e.InitialProblem)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("initialProblem");

                entity.Property(e => e.Laptop)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LAPTOP")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.LastSemester)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LAST_SEMESTER");

                entity.Property(e => e.LastSemesterRemarks)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LAST_SEMESTER_REMARKS");

                entity.Property(e => e.MastersCgpa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("MASTERS_CGPA")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODIFIED_BY");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("MODIFIED_TIME")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NetCredit)
                    .HasColumnName("NET_CREDIT")
                    .HasComputedColumnSql("([PROGRAM_CREDIT]-[EXEMPTED_CREDIT])", false);

                entity.Property(e => e.PassOutDate)
                    .HasColumnType("datetime")
                    .HasColumnName("PASS_OUT_DATE");

                entity.Property(e => e.PassOutSemester)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PASS_OUT_SEMESTER");

                entity.Property(e => e.PaymentScheme).HasColumnName("PAYMENT_SCHEME");

                entity.Property(e => e.PersonId).HasColumnName("PERSON_ID");

                entity.Property(e => e.PersonalInterest)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("personalInterest");

                entity.Property(e => e.ProgramCredit)
                    .HasColumnName("PROGRAM_CREDIT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Reference)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCE");

                entity.Property(e => e.SecurityCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SECURITY_CODE");

                entity.Property(e => e.Shift)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SHIFT");

                entity.Property(e => e.SscCgpa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("SSC_CGPA")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.StrangthOfStudent)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("strangthOfStudent");

                entity.Property(e => e.TotalMarks).HasColumnName("TOTAL_MARKS");

                entity.Property(e => e.TransferId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRANSFER_ID");

                entity.Property(e => e.WeaknessOfStudent)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("weaknessOfStudent");

                entity.HasOne(d => d.FkStudentIdOfRelativeNavigation)
                    .WithMany(p => p.InverseFkStudentIdOfRelativeNavigation)
                    .HasForeignKey(d => d.FkStudentIdOfRelative)
                    .HasConstraintName("FK_SMIS_STUDENT_SMIS_STUDENT_OF_RELATIVE");

                entity.HasOne(d => d.LastSemesterNavigation)
                    .WithMany(p => p.SmisStudentLastSemesterNavigations)
                    .HasForeignKey(d => d.LastSemester)
                    .HasConstraintName("FK_LAST_SEMESTER_ID");

                entity.HasOne(d => d.PassOutSemesterNavigation)
                    .WithMany(p => p.SmisStudentPassOutSemesterNavigations)
                    .HasForeignKey(d => d.PassOutSemester)
                    .HasConstraintName("FK_PASS_OUT_SEMESTER_ID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.SmisStudents)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SMIS_STUDENT_HRM_PERSON");

                entity.HasOne(d => d.Transfer)
                    .WithMany(p => p.InverseTransfer)
                    .HasForeignKey(d => d.TransferId)
                    .HasConstraintName("FK_SMIS_STUDENT_SMIS_STUDENT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
