﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Smoelenboek.Models;
using Smoelenboek.App_Logic;

namespace Smoelenboek.Controllers
{
    [AuthorizeUser]
    public class StudentsController : Controller
    {
        private SmoelenboekContext db = new SmoelenboekContext();

        // GET: Students
        public ActionResult Index(string searchString)
        {
            var students = db.Students.Include(s => s.SchoolGroup);
            if (!String.IsNullOrEmpty(searchString))
            {
                
                students = db.Students.Where(s => s.FirstMidName.Contains(searchString) || s.Hobby.Contains(searchString)).Include(s => s.SchoolGroup);
            }

            return View(students.ToList());
            // var students = db.Students.Include(s => s.SchoolGroup);
            // return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.SchoolGroupId = new SelectList(db.SchoolGroups, "Id", "GroupName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstMidName,SchoolGroupId,Hobby,Password")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SchoolGroupId = new SelectList(db.SchoolGroups, "Id", "GroupName", student.SchoolGroupId);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchoolGroupId = new SelectList(db.SchoolGroups, "Id", "GroupName", student.SchoolGroupId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstMidName,SchoolGroupId,Hobby,Password")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SchoolGroupId = new SelectList(db.SchoolGroups, "Id", "GroupName", student.SchoolGroupId);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost, ActionName("VIP")]
        public JsonResult VIP(int id, string set)
        {
            Student student = db.Students.Find(id);
            if (set == "on")
            {
                student.VIP = true;
            }
            else
            {
                student.VIP = false;
            }
            db.SaveChanges();
            return null;
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
