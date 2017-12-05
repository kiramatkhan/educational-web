using EducationalWebsite.Models;
using EducationalWebsite.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EducationalWebsite.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDbContext db;
        public StudentController()
        {
            db = new ApplicationDbContext();

        }
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        async public Task<ActionResult> StudentDetail()
        {
            return View(await db.Students.Include("Gender").ToListAsync());
        }
        public ActionResult AddStudent()
        {
            var data = db.Genders.ToList();
            var classdata = db.Classes.ToList();
            var SectionList = db.ClassSections.ToList();
            var StdVm = new StudentVm()
            {
                Genders = data,
                Classes=classdata,
               ClassSections=SectionList
                
            };
            return View(StdVm);
        }
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            if (student.Id == 0)
            {
                db.Students.Add(student);
                db.SaveChanges();

            }
            else
            {
                var record = db.Students.SingleOrDefault(m => m.Id == student.Id);
                record.Roll_No = student.Roll_No;
                record.Name = student.Name;
                record.FatherName = student.FatherName;
                record.B_Form = student.B_Form;
                record.GenderId = student.GenderId;
                record.DateofBirth = student.DateofBirth;
                record.Contact = student.Contact;
                record.Address = student.Address;
                record.ClassCode = student.ClassCode;
                record.ClassSection = student.ClassSection;
                db.SaveChanges();
            }
            return RedirectToAction("StudentDetail");
        }
        async public Task<ActionResult> UpdateStudent(int id)
        {
            var std = await db.Students.Include("Gender").Include("Class").Include("ClassSection").SingleOrDefaultAsync(m => m.Id == id);
            var data = db.Genders.ToList();
            var classlist = db.Classes.ToList();
            var Sectionlist = db.ClassSections.ToList();
            var StdVm = new StudentVm()
            {
                Student = std,
                Genders = data,
                 ClassSections= Sectionlist,
                Classes = classlist

            };
            return View("AddStudent", StdVm);
        }
        public ActionResult RemoveStudent(int id)
        {
            var std = db.Students.SingleOrDefault(m => m.Id == id);
           db.Students.Remove(std);
            db.SaveChanges();
            return RedirectToAction("StudentDetail");
        }
        public ActionResult StudentInvoice()
        {
            return View();
        }
        async public Task<ActionResult> StudentProfile(int id)
        {
            var std = await db.Students.Include("Gender").SingleOrDefaultAsync(m => m.Id == id);

            return View(std);
        }

    }
}