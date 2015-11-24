using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.UI.WebControls;
using GLSOverviewWeb.Models;
using GLSOverviewWeb.Viewmodels;

namespace GLSOverviewWeb.Controllers {
    public enum StatusTypes { Departed, Arrived, Parked }

    public class HomeController : Controller {
        private glsoverviewdbEntities _db = new glsoverviewdbEntities();

        [HttpGet]
        public ActionResult Index() {
            RegistrationModel RM = new RegistrationModel();

            //using (_db)
            //{   
            RM.Cars = _db.cars.ToList();
            return View(RM);
            //}
        }

        [HttpGet]
        public ActionResult EmployeesLogin(RegistrationModel rm) {
            using (_db) {
                var top5 = (from e in _db.employees
                           from r in _db.registrations.Where(x => x.EmployeeId == e.Id).DefaultIfEmpty()
                           orderby r.Date descending
                           select e).ToList();

                rm.Employees = top5;
                rm.Car = _db.cars.Find(rm.CarID);
                return View(rm);
            }
        }

        [HttpGet]
        public ActionResult RegisterCarChecked(RegistrationModel rm) {
            rm.Car = _db.cars.Find(rm.CarID);
            rm.Employee = _db.employees.Find(rm.EmployeeID);
            return View(rm);
        }

        [HttpPost, ActionName("RegisterCarChecked")]
        public ActionResult PostRegisterCarChecked(RegistrationModel rm) {
            registration reg = new registration();
            reg.CarId = rm.CarID;
            reg.EmployeeId = rm.EmployeeID;
            reg.Date = DateTime.Now;
            reg.Comment = rm.Comment;
            _db.registrations.Add(reg);

            car car = _db.cars.Find(rm.CarID);
            car.Status = (int)StatusTypes.Parked;

            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}