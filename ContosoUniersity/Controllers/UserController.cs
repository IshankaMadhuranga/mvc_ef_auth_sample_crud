using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ContosoUniersity.Models;
using ContosoUniersity.DAL;
using System.Data;
using System.Web.Security;

namespace ContosoUniersity.Controllers
{
    public class UserController : Controller
    {
        [AllowAnonymous]
        public ActionResult LogIn()
        {
            if (HttpContext.User.Identity.IsAuthenticated && HttpContext.User.Identity.Name != "")
            {
                return RedirectToAction("Index", "Student");
            }
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoggedIn(LogIn login)
        {
           
                try
                {
                    if (ModelState.IsValid) {
                        using (SchoolContext db = new SchoolContext())
                        {
                            var usr = db.Users.Single(u => u.Email == login.Email && u.Password == login.Password);
                            if (usr.Email != null && usr.Email != "")
                            {
                                FormsAuthentication.SignOut();
                                FormsAuthentication.SetAuthCookie(login.Email, false);
                              
                                return RedirectToAction("Index", "Student");

                            }
                            else
                            {
                               // ModelState.AddModelError("", "Username or password not match.");
                                return View("LogIn", login);
                            }
                        }
                    }
                    else
                    {
                        return View("LogIn", login);
                    }
                }
                catch
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Username or password not match.");
                    return View("LogIn", login);
                }
                
            
            
        }
        //
        // GET: /User/
        [AllowAnonymous]
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create([Bind(Include = "FirtName, LastName, Email,Password")]User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(SchoolContext db = new SchoolContext()){
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index","Student");
                    }
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View("Index", user);
        }
       
	}
}