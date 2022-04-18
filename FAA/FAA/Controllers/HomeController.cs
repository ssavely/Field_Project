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
        private DB_128040_faaEntities3 DB = new DB_128040_faaEntities3();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
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
          

            return View();
        }
        public ActionResult Old()
        {
            return View();
        }
    }
}