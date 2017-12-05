using EducationalWebsite.Models;
using EducationalWebsite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducationalWebsite.Controllers
{
    public class TeacherController : Controller
    {
        ApplicationDbContext absd;
        public TeacherController()
        {
            absd = new ApplicationDbContext();
        }

        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        //To show Detail of Employess
        public ActionResult TeacherDetail()
        {
            var Data = absd.Tacehers.ToList();

            return View(Data);
        }
        public ActionResult AddTeacher()
        {
            var Data = absd.Genders.ToList();
            var TachVm = new TeacherVm()
            {
Genders=Data
            };

            return View(TachVm);
        }
        [HttpPost]
        public ActionResult AddTeacher(TeacherVm emp)
        {
            if (emp.Teacher.Id == 0)
            {
                absd.Tacehers.Add(emp.Teacher);
                absd.SaveChanges();
            }
            else
            {
                var record = absd.Tacehers.SingleOrDefault(m => m.Id == emp.Teacher.Id);
                record.Id = emp.Teacher.Id;
                record.FirstName = emp.Teacher.FirstName;
                record.LastName = emp.Teacher.LastName;
                record.DateofBirth = emp.Teacher.DateofBirth;
                record.Phone = emp.Teacher.Phone;
                record.Address = emp.Teacher.Address;
                absd.SaveChanges();
            }


            return RedirectToAction("TeacherDetail");
        }
        public ActionResult DeleteTeacher(int Id)
        {
            var emp = absd.Tacehers.SingleOrDefault(m => m.Id == Id);
            if (emp != null)
            {
                absd.Tacehers.Remove(emp);
                absd.SaveChanges();
            }
            return RedirectToAction("TeacherDetail");
        }
        public ActionResult TeacherUpdate(int Id)
        {
            var emp = absd.Tacehers.SingleOrDefault(m => m.Id == Id);
            return View("AddEmp", emp);
        }
        public ActionResult Teacherprofile(int Id)
        {
            var data = absd.Tacehers.SingleOrDefault(m => m.Id == Id);
            return View(data);
        }
    }
}
