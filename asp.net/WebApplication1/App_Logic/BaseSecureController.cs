using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smoelenboek.App_Logic
{

    public class AuthorizeUserAttribute: AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (httpContext.User.Identity.IsAuthenticated)
            {
                if (httpContext.Session["Role"]== null)
                {
                    return false;
                }
     
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