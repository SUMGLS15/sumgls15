﻿using System;
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
                var registrationList = db.registrations.Include(r => r.car).Include(e => e.employee).Where(r => r.Comment != null).Where(r => r.CommentHandled == false).ToList();
                am.RegistrationList = registrationList;
            }

            am.Employee = LoginController.CurrentUser();
            return View(am);
        }

        [HttpPost]
        public ActionResult RegistrationChecked(int id) {
            if (!LoginController.IsAdmin()) {
                return View("~/Views/Login/Index.cshtml");
            }
            using (glsoverviewdbEntities db = new glsoverviewdbEntities()) {
                registration reg = db.registrations.Find(id);
                reg.CommentHandled = true;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}