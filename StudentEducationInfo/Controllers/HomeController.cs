using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentEducationInfo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEducationInfo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ERPContext _context;
        public HomeController(ILogger<HomeController> logger, ERPContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Degree = _context.HrmDegrees.ToList();
            ViewBag.StudentID = "";
            ViewBag.flag = 0;
            return View();
        }
        
        public IActionResult Toggle(string StudentID,int flag)
        {
            ViewBag.Degree = _context.HrmDegrees.ToList();
            ViewBag.StudentID = "";
            if(flag==0)
            {
                ViewBag.flag = 1;
            }
            else if(flag==1){
                ViewBag.flag = 0;
            }

            ViewBag.StudentID = StudentID;
            return View("Index");
        }

        [HttpPost]

        public IActionResult GetEducationByID(string StudentID)
        {

            ViewBag.StudentID = StudentID;
            List <StudentEducationModel> studentEducations= _context.SmisStudents.Where(x => x.StudentId == StudentID).ToList().Join(_context.HrmEducations.ToList(),

                                                student => student.PersonId,
                                                education => education.PersonId,
                                                (student, education) => new StudentEducationModel
                                                {
                                                    StudentID = student.StudentId,
                                                    Degree = education.Degree,
                                                    MajorSubject = education.MajorSubject,
                                                    Institute = education.Institute,
                                                    Board = education.UniversityBoard,
                                                    PassingYear = education.PassingYear,
                                                    CGPA = education.Cgpa,
                                                    PersonID=student.PersonId

                                                }


                                 ).ToList();

            if(studentEducations.Count!=0)
            HttpContext.Session.SetObject("StudentEduCation", studentEducations);
            else
            HttpContext.Session.SetObject("StudentEduCation", null);
            ViewBag.Degree = _context.HrmDegrees.ToList();
            ViewBag.flag = 0;
            return View("Index");
        }

        //public IActionResult DeleteEducation(long personid, string degree, string StudentID)
        //{
        //    ViewBag.StudentID = StudentID;
        //    List<HrmEducation> Education = _context.HrmEducations.Where(x => x.PersonId == personid && x.Degree == degree).ToList();

        //    foreach (var item in Education)
        //    {
        //        _context.HrmEducations.Remove(item);
        //        _context.SaveChanges();
        //        @TempData["delete"] = "Data Deleted Successfully";
        //    }

        //    return View("Index");
        //}

        public  IActionResult CreateEducation()
        {
            List<string> degreeList = new List<string>();
             List<HrmDegree> degrees =  _context.HrmDegrees.OrderBy(x=>x.Degree).ToList();
            foreach (var item in degrees)
            {
                degreeList.Add(item.Degree);
            }

            ViewBag.Degree = degreeList;


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEducation(StudentEducationModel model)
        {
            

            if(_context.SmisStudents.FirstOrDefault(x => x.StudentId == model.StudentID)!=null)
            model.PersonID = _context.SmisStudents.FirstOrDefault(x=>x.StudentId==model.StudentID).PersonId;

            if ( _context.HrmEducations.FirstOrDefault(x=>x.Degree==model.Degree && x.PersonId==model.PersonID && x.MajorSubject==model.MajorSubject)!=null)
            {
                ViewBag.Degree = _context.HrmDegrees.ToList();
                TempData["noData"] = "Duplicate data Insert Error for" + model.StudentID + " and " + model.Degree;
                this.GetEducationByID(model.StudentID);
                ViewBag.flag = 0;
                ViewBag.StudentID = model.StudentID;
                return View("Index");
            }

            if (model.PersonID != 0)
            {
                HrmEducation education = new HrmEducation()
                {

                    Cgpa = model.CGPA,
                    PersonId = model.PersonID,
                    UniversityBoard = model.Board,
                    MajorSubject = model.MajorSubject,
                    PassingYear = model.PassingYear,
                    Degree = model.Degree,
                    Institute = model.Institute


                };


                ViewBag.Degree = _context.HrmDegrees.ToList();
                TempData["save"] = "Successfully Saved";
                _context.HrmEducations.Add(education);
                 await _context.SaveChangesAsync();
            }
            else
            {
                ViewBag.Degree = _context.HrmDegrees.ToList();
                ViewBag.flag = 0;
                ViewBag.StudentID = model.StudentID;
                TempData["noData"] = "There is no record found within "+model.StudentID;
                return View("Index");
            }

            
            List<StudentEducationModel> studentEducations = _context.SmisStudents.Where(x => x.StudentId == model.StudentID).ToList().Join(_context.HrmEducations.ToList(),

                                                student => student.PersonId,
                                                education => education.PersonId,
                                                (student, education) => new StudentEducationModel
                                                {
                                                    StudentID = student.StudentId,
                                                    Degree = education.Degree,
                                                    MajorSubject = education.MajorSubject,
                                                    Institute = education.Institute,
                                                    Board = education.UniversityBoard,
                                                    PassingYear = education.PassingYear,
                                                    CGPA = education.Cgpa,
                                                    PersonID = student.PersonId

                                                }


                                 ).ToList();

            if (studentEducations.Count != 0)
                HttpContext.Session.SetObject("StudentEduCation", studentEducations);
            else
                HttpContext.Session.SetObject("StudentEduCation", null);
            ViewBag.Degree = _context.HrmDegrees.ToList();
            ViewBag.flag = 0;
            ViewBag.StudentID = model.StudentID;

            return View("Index");


           

            
        }

        public void GetList(string StudentID)
        {
            List<StudentEducationModel> studentEducations = _context.SmisStudents.Where(x => x.StudentId == StudentID).ToList().Join(_context.HrmEducations.ToList(),

                                                student => student.PersonId,
                                                education => education.PersonId,
                                                (student, education) => new StudentEducationModel
                                                {
                                                    StudentID = student.StudentId,
                                                    Degree = education.Degree,
                                                    MajorSubject = education.MajorSubject,
                                                    Institute = education.Institute,
                                                    Board = education.UniversityBoard,
                                                    PassingYear = education.PassingYear,
                                                    CGPA = education.Cgpa,
                                                    PersonID = student.PersonId

                                                }


                                 ).ToList();

            if (studentEducations.Count != 0)
                HttpContext.Session.SetObject("StudentEduCation", studentEducations);
            else
                HttpContext.Session.SetObject("StudentEduCation", null);
        }
        [HttpGet]
        public IActionResult EditEducation(StudentEducationModel model)
        {
                ViewBag.Degree = _context.HrmDegrees.ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditEducations(StudentEducationModel model)
        {
            if (model != null)
            {
                var hrmEducation = _context.HrmEducations.FirstOrDefault(x => x.Degree == model.Degree && x.PersonId == model.PersonID && x.MajorSubject == model.MajorSubject);





                hrmEducation.Institute = model.Institute;
                hrmEducation.UniversityBoard = model.Board;
                hrmEducation.PassingYear = model.PassingYear;
                hrmEducation.Cgpa = model.CGPA;
                
               
                _context.HrmEducations.Update(hrmEducation);
                await _context.SaveChangesAsync();
            }
            else
            {
                TempData["noData"] = "Can not be updated";
                return View(model);
            }







            ViewBag.Degree = _context.HrmDegrees.ToList();
            List<StudentEducationModel> studentEducations = _context.SmisStudents.Where(x => x.StudentId == model.StudentID).ToList().Join(_context.HrmEducations.ToList(),

                                                student => student.PersonId,
                                                education => education.PersonId,
                                                (student, education) => new StudentEducationModel
                                                {
                                                    StudentID = student.StudentId,
                                                    Degree = education.Degree,
                                                    MajorSubject = education.MajorSubject,
                                                    Institute = education.Institute,
                                                    Board = education.UniversityBoard,
                                                    PassingYear = education.PassingYear,
                                                    CGPA = education.Cgpa,
                                                    PersonID = student.PersonId

                                                }


                                 ).ToList();

            if (studentEducations.Count != 0)
                HttpContext.Session.SetObject("StudentEduCation", studentEducations);
            else
                HttpContext.Session.SetObject("StudentEduCation", null);

            TempData["save"] = "Updated Successfully";
            ViewBag.StudentID = model.StudentID;
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
