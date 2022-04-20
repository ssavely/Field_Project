using FAA.Models;
using FAA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FAA.Controllers
{
    public class HomeController : Controller
    {
        private DB_128040_faaEntities5 DB = new DB_128040_faaEntities5();

        public ActionResult Index()
        {
            var tables = new FAADatabaseClass();

            tables.instructors = DB.Instructors.ToList();
            tables.pcns = DB.PCNs.ToList();
            tables.courses = DB.Courses.ToList();
            tables.lessons = DB.Lessons.ToList();

            return View(tables);
        }

        public ActionResult InstructorCourse()
        {
            var tables = new FAADatabaseClass();

            tables.instructors = DB.Instructors.ToList();
            tables.pcns = DB.PCNs.ToList();
            tables.courses = DB.Courses.ToList();
            tables.lessons = DB.Lessons.ToList();

            return View(tables);
        }

        public ActionResult Open()
        {
            var tables = new FAADatabaseClass();

            tables.instructors = DB.Instructors.ToList();
            tables.pcns = DB.PCNs.ToList();
            tables.courses = DB.Courses.ToList();
            tables.lessons = DB.Lessons.ToList();

            return View(tables);
        }
        public ActionResult History()
        {
            var tables = new FAADatabaseClass();

            tables.instructors = DB.Instructors.ToList();
            tables.pcns = DB.PCNs.ToList();
            tables.courses = DB.Courses.ToList();
            tables.lessons = DB.Lessons.ToList();
            tables.PCN_Audits = DB.PCN_Audit.ToList();
            return View(tables);
        }
    }
}