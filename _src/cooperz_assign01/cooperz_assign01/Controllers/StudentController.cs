using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cooperz_assign01.Models;

namespace cooperz_assign01.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var studentList = new List<Student>
            {
                new Student() {StudentId = 1, StudentName = "Zach", Age = 22},
                new Student() {StudentId = 2, StudentName = "Steve", Age = 23},
            };

            return View(studentList);
        }
    }
}