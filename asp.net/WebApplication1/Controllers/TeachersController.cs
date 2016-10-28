using System;
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
    public class TeachersController : Controller
    {
        private SmoelenboekContext db = new SmoelenboekContext();

        // GET: Teachers
        public ActionResult Index(string searchString)
        {
            var teachers = db.Teachers.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                teachers = db.Teachers.Where(s => s.FirstMidName.Contains(searchString) || s.Hobby.Contains(searchString)).ToList();
            }

            return View(teachers);
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
            var teacher = db.Teachers.Include(t => t.SchoolGroups).Single(t => t.Id == id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchoolGroupId = new SelectList(db.SchoolGroups, "Id", "GroupName"); // schoolgroep id is een lijst van schoolgroepen uit db met id en naam
            ViewBag.AllGroups = db.SchoolGroups.ToList(); // alle groepen is schoolgroepenen uit db naar lijst.. compleet?
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Teacher teacher, List<int> schoolgroupIds)
        {
            var dbTeacher = db.Teachers.Include(t => t.SchoolGroups).Single(t => t.Id == teacher.Id);
            if (TryUpdateModel(dbTeacher))
            {
                dbTeacher.SchoolGroups.Clear();
                //   teacher.SchoolGroups = new List<SchoolGroup>();
                if (schoolgroupIds != null)
                {
                    foreach (var group in schoolgroupIds)
                    {
                        // dit is een extra db query per foreach lus... is niet mooi natuurlijk, maar werkt wel
                        // als je tijd hebt mag je nadenken hoe dit mooier kan :P
                        SchoolGroup sg = db.SchoolGroups.Where(s => s.Id == group).FirstOrDefault();
                        dbTeacher.SchoolGroups.Add(sg);
                    }
                }

               
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

        public JsonResult VIP(int id, string set)
        {
            Teacher teacher = db.Teachers.Find(id);
            if (set == "on")
            {
                teacher.VIP = true;
            }
            else
            {
                teacher.VIP = false;
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
