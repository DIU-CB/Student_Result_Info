using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using StudentEducationInfo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEducationInfo.Controllers
{
    public class VoterID : Controller
    {
        private readonly ERPContext _context;

        public VoterID(ERPContext context)
        {

            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.msg = "";
            return View();
        }

        public IActionResult VoterIDExcelUpload()
        {
            ViewBag.Student = null;

            return View();
        }


        [HttpPost]

        public async Task<IActionResult> VoterIDExcelUpload(IFormFile file)
        {
            if (file == null)
            {
                ViewBag.msg = "Please Select an Excel File";
                return View();
            }
            var StudentList = new List<VoterIDModel>();

            using (var Stream = new MemoryStream())
            {
                await file.CopyToAsync(Stream);

                using (var Package = new ExcelPackage(Stream))
                {
                    ExcelWorksheet worksheet = Package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;

                    
                    for (int row = 2; row <= rowcount; row++)
                    {
                        if (worksheet.Cells[row, 1].Value != null && worksheet.Cells[row, 2].Value != null)
                        {

                            VoterIDModel student = new VoterIDModel();
                            student.StudentId = worksheet.Cells[row, 1].Value.ToString().Trim();
                            student.VoterId = worksheet.Cells[row, 2].Value.ToString().Trim();


                            StudentList.Add(student);
                        }

                    }
                }
            }

            List<VoterIDModel> No_student_Infos = new List<VoterIDModel>();
            foreach (var student in StudentList)
            {
                var Check_PersonID = _context.SmisStudents.FirstOrDefault(x => x.StudentId == student.StudentId);
                if (Check_PersonID != null)
                {
                    var person = _context.HrmPeople.FirstOrDefault(x => x.PersonId == Check_PersonID.PersonId);


                    if (person != null)
                    {
                        person.VoterId = student.VoterId;
                        _context.HrmPeople.Update(person);
                    }


                    person = null;
                    Check_PersonID = null;
                }
                else
                {
                    ViewBag.msg = "Some Students ID did not Exist, Valid students VoterID updated successfully";

                    No_student_Infos.Add(student);
                }

            }


            await _context.SaveChangesAsync();


            if (No_student_Infos.Count == 0)
            {
                ViewBag.msg = "All VoterID updated Successfully";
                return View();
            }
            else
            {
                return View(No_student_Infos);
            }



        }

        [HttpPost]
        public async Task<IActionResult> GetVoterIdByStudentID(string ID)
        {
            if (ID != null)
            {
                if (await _context.SmisStudents.FindAsync(ID) != null)
                {
                    var PersonID = _context.SmisStudents.FirstOrDefault(x => x.StudentId == ID).PersonId;
                    VoterIDModel VoterID = new VoterIDModel()
                    {
                        PersonId = PersonID,
                        StudentId = ID,
                        VoterId = _context.HrmPeople.FirstOrDefault(x => x.PersonId == PersonID).VoterId
                    };
                    
                    return View("Index",VoterID);
                }
                else
                {
                    ViewBag.msg = ID + " not found";
                    return View("Index");
                }
            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SaveorUpdateVoterID(VoterIDModel model)
        {
            HrmPerson person = _context.HrmPeople.FirstOrDefault(x => x.PersonId == model.PersonId);
            person.VoterId = model.VoterId;

            _context.HrmPeople.Update(person);
            await _context.SaveChangesAsync();

            ViewBag.msg = model.StudentId +" Voter ID Number is Changed to "+model.VoterId;
            return View("Index");
        }

        public IActionResult  VoterIDChecking()
        {
            ViewBag.SemesterList = _context.SmisSemesters.OrderByDescending(x => x.SemesterId).ToList();
            ViewBag.msg = "There is no email value according to this Semester or Semester is not Selected";
            return View();
        }

        [HttpPost]
        [Route("/VoterID/VoterIDChecking/{Semester?}")]
        public IActionResult VoterIDChecking(string Semester)
        {
            if (Semester == "0")
            {
                ViewBag.msg = "Select an Semester";
                return View();
            }
            //var Students = _context.SmisStudents.Where(x=>x.StudentId.Contains(Semester)).ToList();
            var people = _context.SmisStudents.Where(x => x.StudentId.Contains(Semester)).ToList().Join(_context.HrmPeople.ToList(),
                                        student => student.PersonId,
                                        person => person.PersonId,
                                        (student, person) => new VoterIDModel
                                        {

                                            StudentId = student.StudentId,
                                            StudentName = person.FirstName,
                                            VoterId = person.VoterId,
                                          



                                        }).Where(x => x.VoterId == null || x.VoterId == "").ToList();


            ViewBag.SemesterList = _context.SmisSemesters.OrderByDescending(x => x.SemesterId).ToList();
            return View(people);
        }
    }
}
