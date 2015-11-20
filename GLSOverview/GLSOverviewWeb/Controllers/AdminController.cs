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

        public ActionResult Index()
        {
            if (!LoginController.IsAdmin())
                return View("~/Views/Login/Index.cshtml");

            return View(LoginController.CurrentUser());
        }


    }
}