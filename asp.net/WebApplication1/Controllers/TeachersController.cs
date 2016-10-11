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
    public class TeachersController : Controller
    {
        private SmoelenboekContext db = new SmoelenboekContext();

        // GET: Teachers
        public ActionResult Index()
        {
            // afvangen van rechten???? daarop view aanpassen? login systeem? 
            return View(db.Teachers.ToList());
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            ViewBag.SchoolGroupId = new SelectList(db.SchoolGroups, "Id", "GroupName"); // schoolgroep id is een lijst van schoolgroepen uit db met id en naam

            ViewBag.AllGroups = db.SchoolGroups.ToList(); // alle groepen is schoolgroepenen uit db naar lijst.. compleet?
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Teacher teacher, List<int> schoolgroupIds) // haal post schoolgroupids op lees name="SchoolGroupIds" value="@group.Id" array. 
        {
            if (ModelState.IsValid)
            {
               teacher.SchoolGroups = new List<SchoolGroup>(); // teacher.schoolgroups is nog leeg. hier maken we  de NULL naar een lege array. 
                foreach(var group in schoolgroupIds) // voor elke 'groep' in de post schoolgroupids. 
                {
                    var dbGroup = db.SchoolGroups.Find(group); // maak lege waarde dbgroep aan. en vul deze met een groep die je vind op basis van ID uit loop. uit de post.
                    teacher.SchoolGroups.Add(dbGroup); // vul nu of voeg nu deze gevonden groep toe aan de net gemaakte array in leraar model. 
                }


                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstMidName,Hobby,PictureURL")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
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
