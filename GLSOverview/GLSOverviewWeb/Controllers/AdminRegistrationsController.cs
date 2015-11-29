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
        private glsoverviewdbEntities db = new glsoverviewdbEntities();

        // GET: AdminRegistrations
        public ActionResult Index()
        {
            var registrations = db.registrations.Include(r => r.car).Include(r => r.employee);
            return View(registrations.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
