using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Smoelenboek.Models;

namespace Smoelenboek.Controllers
{
    public class SchoolGroupsController : Controller
    {
        private SmoelenboekContext db = new SmoelenboekContext();

        // GET: SchoolGroups
        public ActionResult Index()
        {
            return View(db.SchoolGroups.ToList());
        }

        // GET: SchoolGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolGroup schoolGroup = db.SchoolGroups.Find(id);
            if (schoolGroup == null)
            {
                return HttpNotFound();
            }
            return View(schoolGroup);
        }

        // GET: SchoolGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GroupName")] SchoolGroup schoolGroup)
        {
            if (ModelState.IsValid)
            {
                db.SchoolGroups.Add(schoolGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schoolGroup);
        }

        // GET: SchoolGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolGroup schoolGroup = db.SchoolGroups.Find(id);
            if (schoolGroup == null)
            {
                return HttpNotFound();
            }
            return View(schoolGroup);
        }

        // POST: SchoolGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GroupName")] SchoolGroup schoolGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schoolGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schoolGroup);
        }

        // GET: SchoolGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolGroup schoolGroup = db.SchoolGroups.Find(id);
            if (schoolGroup == null)
            {
                return HttpNotFound();
            }
            return View(schoolGroup);
        }

        // POST: SchoolGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SchoolGroup schoolGroup = db.SchoolGroups.Find(id);
            db.SchoolGroups.Remove(schoolGroup);
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
