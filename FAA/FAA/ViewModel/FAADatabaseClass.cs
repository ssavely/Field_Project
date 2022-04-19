using FAA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAA.ViewModel
{
    public class FAADatabaseClass
    {
        public IEnumerable<Instructor> instructors { get; set; }
        public IEnumerable<PCN> pcns { get; set; }
        public IEnumerable<Course> courses { get; set; }
        public IEnumerable<Lesson> lessons { get; set; }
        public IEnumerable<PCN_Audit> PCN_Audits { get; set; }

    }

}