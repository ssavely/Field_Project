using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FAA.Models;
using FAA.ViewModel;

namespace FAA.Controllers
{
    public class PCNsController : Controller
    {
        private DB_128040_faaEntities4 db = new DB_128040_faaEntities4();

        // GET: PCNs
        public ActionResult Open()
        {
            var tables = new FAADatabaseClass();

            tables.instructors = db.Instructors.ToList();
            tables.pcns = db.PCNs.ToList();
            tables.courses = db.Courses.ToList();
            tables.lessons = db.Lessons.ToList();

            return View(tables);
        }
        public ActionResult ClosedPCN()
        {
            var tables = new FAADatabaseClass();

            tables.instructors = db.Instructors.ToList();
            tables.pcns = db.PCNs.ToList();
            tables.courses = db.Courses.ToList();
            tables.lessons = db.Lessons.ToList();

            return View(tables);
        }

        // GET: PCNs/Create
        public ActionResult Create()
        {

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseID");
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorID");


            return View();
        }

        // POST: PCNs/Create
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

        // GET: PCNs/Edit/5
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
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseID", pCN.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "InstructorID", pCN.InstructorID);
            return View(pCN);
        }

        // POST: PCNs/Edit/5
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

        // GET: PCNs/Delete/5
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

        // POST: PCNs/Delete/5
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
