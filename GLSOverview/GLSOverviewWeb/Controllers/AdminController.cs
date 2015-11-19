using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GLSOverviewWeb.Models;

namespace GLSOverviewWeb.Controllers
{
    public class AdminController : Controller
    {
        private glsoverviewdbEntities db = new glsoverviewdbEntities();
        // GET: Admin
        public ActionResult Index()
        {
            if (EnsureAdmin() == true) {
                return View("~/Views/Admin/Index.cshtml");
            }
            else
                return RedirectToAction("Index", "Login");
        }

        private bool? EnsureAdmin() {
            employee emp = (employee)Session["UserAdmin"];
            return emp.Admin;
        }
    }
}