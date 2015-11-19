using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GLSOverviewWeb.Models;

namespace GLSOverviewWeb.Controllers
{
    public class LoginController2 : Controller
    {
        private glsoverviewdbEntities db = new glsoverviewdbEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View("~/Views/Login/Index.cshtml");
        }

        [HttpPost]
        public ActionResult Index(employee emp)
        {
            var login = db.employees
                          .FirstOrDefault(e => e.EmpNo == emp.EmpNo &&
                                               e.Password == emp.Password);
            EnsureLoggedIn();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult EnsureLoggedIn()
        {
            employee e = CurrentUser();
            if (e == null)
                return RedirectToAction("Index", "Login", new { msg = "You need to login"});
        }

        public ActionResult EnsureLoggedInAsAdmin()
        {
            employee e = CurrentUser();
            if (e == null || !e.Admin)
                return RedirectToAction("Index", "Login");
        }

        public employee CurrentUser()
        {
            return (employee)Session["UserAdmin"];
        }

    }
}