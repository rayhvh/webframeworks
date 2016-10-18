using AuthenticationTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Smoelenboek.Models;

namespace AuthenticationTest.Controllers
{
    public class AccessController : Controller
    {
        private SmoelenboekContext db = new SmoelenboekContext();
        // GET: Access
        public ActionResult Login()
        {

            // the following code could be used to always redirect the user 
            // to the secure page if already logged in...
            //    if ( User.Identity.IsAuthenticated)
            //  {
            //       return RedirectToAction("Index", "Secure");
            //  }

            return View();
        }


        public ActionResult Logout()
        {

            // remove security cookie
            FormsAuthentication.SignOut();

            // best practice: clear the session 
            Session.Clear();

            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginVM data)
        {
            
            var ingelogtestudent = db.Students.Where(u => u.FirstMidName == data.Username && u.Password == data.Password);
            if (ingelogtestudent.Any())
            {
                // login the user, and redirect to the 'secret' page..
  
                // this method sets the .net authentication cookie. from this 
                // moment on we are 'authenticated' .net style. (note that you could
                // pass any string into the username argument. Including a database Id..
                FormsAuthentication.SetAuthCookie(data.Username, true);

                // optional: set something in the session to determine different roles (e.g. administrator or user).
                Session["Role"] = "Student";
                return RedirectToAction("Index", "Student");
            }

            var ingelogteteacher = db.Teachers.Where(u => u.FirstMidName == data.Username && u.Password == data.Password);
            if (ingelogteteacher.Any())
            {
                FormsAuthentication.SetAuthCookie(data.Username, true);
                Session["Role"] = "Teacher";
                return RedirectToAction("Index", "Teacher");
            }

            else
            {

                ModelState.AddModelError("", "De gebruikersnaam komt niet voor, of het wachtwoord is verkeerd. Probeer het opnieuw.");

                return View(data);
            }
        }
    }
}