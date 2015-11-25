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
            employee.Password = Sha1.Encode(employee.Password);

            var login = _db.employees
                           .FirstOrDefault(e => e.EmpNo == employee.EmpNo &&
                                                e.Password == employee.Password);
            if (login == null)
                return View(); // TODO Msg: Bad login

            Session["User"] = login; // Gad vide om en hacker kan hente sessionen ud og lægge sessionen ind senere?

            return RedirectToAction("Index", "Admin");
            // TODO Kunne være rart at lave noget "redirect til hvor du kom fra"
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


        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}