using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smoelenboek.App_Logic
{
    /// <summary>
    /// Option 1: default base controller that should  be extended.
    /// override the onAuthorization to determine if the user may login in
    /// based on a session value.
    ///  
    /// Note that the session expiration may be different then the cookie expiration!
    /// the best practice would be to check if the session value is null, if null
    /// get role from database and update session. 
    /// Other option would be to update the web.config to set the session time to be greater
    /// then the cookie/security timeout! But if IIS crashes, the session will still be cleared
    /// and the cookie remains..
    /// </summary>
    [Authorize()]
    public class BaseSecureController : Controller
    {

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // possible roles in session

                if (!filterContext.HttpContext.Session["Role"].Equals("User"))
                {

                    // redirect to error page... by setting the result
                    filterContext.Result = RedirectToAction("Unauthorized", "Access");

                }

                // else we do nothing, meaning you are allowed to continue..
            }
        }
    }

    /// <summary>
    /// Option 2: a custom authorize attribute. Decorate each controller with 
    /// this attribute and perform the same check in authorizeCore.
    /// return true/false based on if the user is allowed to view content.

    /// Note that the session expiration may be different then the cookie expiration!
    /// the best practice would be to check if the session value is null, if null
    /// get role from database and update session. 
    /// Other option would be to update the web.config to set the session time to be greater
    /// then the cookie/security timeout! But if IIS crashes, the session will still be cleared
    /// and the cookie remains.
    /// </summary>
    public class AuthorizeUserAttribute: AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (httpContext.User.Identity.IsAuthenticated)
            {
                if (httpContext.Session["Role"].Equals("Student"))
                {
                   
                    return true;
                }
                else if (httpContext.Session["Role"].Equals("Teacher"))
                {

                    return true;
                }

            }
            return false;

        }
    }
}