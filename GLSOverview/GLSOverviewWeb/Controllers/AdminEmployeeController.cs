using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GLSOverviewWeb.Models;

namespace GLSOverviewWeb.Controllers {
    public class AdminEmployeeController : Controller {
        // GET: AdminEmployee
        public ActionResult Index() {
            List<employee> resList = new List<employee>();
            using (glsoverviewdbEntities db = new glsoverviewdbEntities()) {
                var query = from e in db.employees
                            orderby e.Name descending
                            select e;
                foreach (var emp in query) {
                    resList.Add(emp);
                }
            }
            return View(resList);
        }

        [HttpGet]
        public ActionResult AddEmployee() {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(employee emp) {
            using (glsoverviewdbEntities db = new glsoverviewdbEntities()) {
                db.employees.Add(emp);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "AdminEmployee");
        }

        [HttpGet]
        public ActionResult EditEmployee(int id) {
            using (glsoverviewdbEntities db = new glsoverviewdbEntities()) {
                employee emp = db.employees.Find(id);
                return View(emp);
            }
        }

        [HttpPost]
        public ActionResult EditEmployee(employee emp) {
            using(glsoverviewdbEntities db = new glsoverviewdbEntities()) {
            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int id) {
            using (glsoverviewdbEntities db = new glsoverviewdbEntities()) {
                employee emp = db.employees.Find(id);
                return View(emp);
            }
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult PostDeleteEmployee(int id) {
            using (glsoverviewdbEntities db = new glsoverviewdbEntities()) {
                employee emp = db.employees.Find(id);
                db.employees.Remove(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}