using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GLSOverviewWeb.Models;
using GLSOverviewWeb.Viewmodels;

namespace GLSOverviewWeb.Controllers {
    public class AdminController : Controller {

        public ActionResult Index(AdminModel am) {
            if (!LoginController.IsAdmin()) {
                return View("~/Views/Login/Index.cshtml");
            }
            using (glsoverviewdbEntities db = new glsoverviewdbEntities()) {
                var registrationList = db.registrations.Include(r => r.car).ToList();
                                        //join c in db.cars on r.CarId equals c.Id
                                        //where r.Comment != null
                                        //orderby r.Date descending
                                        //select r).ToList();
                am.RegistrationList = registrationList;
            }

            am.Employee = LoginController.CurrentUser();
            return View(am);
        }

        [HttpGet]
        public ActionResult RegistrationDetails(int id) {
            if (!LoginController.IsAdmin()) {
                return View("~/Views/Login/Index.cshtml");
            }
            using (glsoverviewdbEntities db = new glsoverviewdbEntities()) {
                var reg = from r in db.registrations
                          where r.CarId == id
                          select r;
                return View(reg);
            }
        }

        //[HttpPost]
        //public ActionResult RegistrationDetails(registration reg) {
        //    if (!LoginController.IsAdmin()) {
        //        return View("~/Views/Login/Index.cshtml");
        //    }
        //    using (db) {
        //        registration tempReg = db.registrations.Find(reg.Id);
        //        tempReg.
        //    }
        //}


    }
}