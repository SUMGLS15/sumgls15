using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Add()
        {
            if (!LoginController.IsAdmin())
                return View("~/Views/Login/Index.cshtml");

            return View();
        }

        [HttpPost]
        public ActionResult Add(employee emp)
        {
            if (!LoginController.IsAdmin())
                return View("~/Views/Login/Index.cshtml");

            using (glsoverviewdbEntities db = new glsoverviewdbEntities())
            {
                db.employees.Add(emp);
                db.SaveChanges();
            }
            
            return RedirectToAction("Index", "AdminEmployee");
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