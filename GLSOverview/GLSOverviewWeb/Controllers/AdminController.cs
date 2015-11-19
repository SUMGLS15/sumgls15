using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GLSOverviewWeb.Controllers
{
    public class AdminController : Controller
    {
        private glsoverviewdbEntities db = new glsoverviewdbEntities();
        // GET: Admin
        public ActionResult Index(employee emp)
        {
            return View(emp);
        }
    }
}