using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using GLSOverviewWeb.Helpers;
using GLSOverviewWeb.Models;

namespace GLSOverviewWeb.Controllers
{
    public class LoginController : Controller
    {
        private glsoverviewdbEntities _db = new glsoverviewdbEntities();

        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(employee employee)
        {
            if (employee == null)
                return HttpNotFound();

            employee.Password = Sha1.Encode(employee.Password);

            var login = _db.employees
                           .FirstOrDefault(e => e.EmpNo == employee.EmpNo &&
                                                e.Password == employee.Password);

            if (login == null)
            {
                ModelState.AddModelError("password", "The username or password is incorrect");
                return View();
            }

            Session["User"] = login;

            return RedirectToAction("Index", "Admin");
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }

        public static bool IsLoggedIn()
        {
            var emp = CurrentUser();
            return (emp != null);
        }

        public static bool IsAdmin()
        {
            var emp = CurrentUser();
            return (emp != null && emp.Admin);
        }

        public static employee CurrentUser()
        {
            return (employee)System.Web.HttpContext.Current.Session["User"];
        }
    }
}