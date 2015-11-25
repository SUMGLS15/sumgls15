using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GLSOverviewWeb.Helpers;
using GLSOverviewWeb.Models;

namespace GLSOverviewWeb.Controllers
{
    public class AdminEmployeesController : Controller
    {
        // GET: AdminEmployee
        public ActionResult Index()
        {
            if (!LoginController.IsAdmin())
                return View("~/Views/Login/Index.cshtml");

            List<employee> resList = new List<employee>();
            using (glsoverviewdbEntities db = new glsoverviewdbEntities())
            {
                var query = from e in db.employees
                            orderby e.Name descending
                            select e;
                foreach (var emp in query)
                {
                    resList.Add(emp);
                }
            }
            return View(resList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (!LoginController.IsAdmin())
                return View("~/Views/Login/Index.cshtml");

            return View();
        }

        [HttpPost]
        public ActionResult Create(employee emp)
        {
            if (!LoginController.IsAdmin())
                return View("~/Views/Login/Index.cshtml");

            using (glsoverviewdbEntities db = new glsoverviewdbEntities())
            {
                emp.Password = Sha1.Encode(emp.Password);

                db.employees.Add(emp);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine(
                            "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
            
            return RedirectToAction("Index", "AdminEmployees");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (!LoginController.IsAdmin())
                return View("~/Views/Login/Index.cshtml");


            using (glsoverviewdbEntities db = new glsoverviewdbEntities())
            {
                employee emp = db.employees.Find(id);
                return View(emp);
            }
        }

        [HttpPost]
        public ActionResult Edit(employee emp)
        {
            using (glsoverviewdbEntities db = new glsoverviewdbEntities())
            {
                emp.Password = Sha1.Encode(emp.Password);

                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (glsoverviewdbEntities db = new glsoverviewdbEntities())
            {
                employee emp = db.employees.Find(id);
                return View(emp);
            }
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult PostDelete(int id)
        {
            using (glsoverviewdbEntities db = new glsoverviewdbEntities())
            {
                employee emp = db.employees.Find(id);
                db.employees.Remove(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}