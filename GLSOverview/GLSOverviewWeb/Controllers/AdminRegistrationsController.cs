using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GLSOverviewWeb.Models;

namespace GLSOverviewWeb.Controllers
{
    public class AdminRegistrationsController : Controller
    {
        // GET: AdminRegistrations
        public ActionResult Index()
        {
            if (!LoginController.IsAdmin())
                return View("~/Views/Login/Index.cshtml");

            using (var db = new glsoverviewdbEntities())
            {
                var registrations = db.registrations.Include(r => r.car).Include(r => r.employee);
                return View(registrations.ToList());
            }
        }
    }
}
