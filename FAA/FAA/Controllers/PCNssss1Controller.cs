using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FAA.Models;

namespace FAA.Controllers
{
    public class PCNssss1Controller : Controller
    {
        private DB_128040_faaEntities4 db = new DB_128040_faaEntities4();

        // GET: PCNssss1
        public ActionResult Index()
        {
            var pCNs = db.PCNs.Include(p => p.Course).Include(p => p.Instructor);
            return View(pCNs.ToList());
        }

        // GET: PCNssss1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCN pCN = db.PCNs.Find(id);
            if (pCN == null)
            {
                return HttpNotFound();
            }
            return View(pCN);
        }

        // GET: PCNssss1/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseNo");
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "FirstName");
            return View();
        }

        // POST: PCNssss1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PCNID,CourseID,InstructorID,StartDate,EndDate,Description,IsApproved")] PCN pCN)
        {
            if (ModelState.IsValid)
            {
                db.PCNs.Add(pCN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseNo", pCN.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "FirstName", pCN.InstructorID);
            return View(pCN);
        }

        // GET: PCNssss1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCN pCN = db.PCNs.Find(id);
            if (pCN == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseNo", pCN.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "FirstName", pCN.InstructorID);
            return View(pCN);
        }

        // POST: PCNssss1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PCNID,CourseID,InstructorID,StartDate,EndDate,Description,IsApproved")] PCN pCN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pCN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseNo", pCN.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "FirstName", pCN.InstructorID);
            return View(pCN);
        }

        // GET: PCNssss1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCN pCN = db.PCNs.Find(id);
            if (pCN == null)
            {
                return HttpNotFound();
            }
            return View(pCN);
        }

        // POST: PCNssss1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PCN pCN = db.PCNs.Find(id);
            db.PCNs.Remove(pCN);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
