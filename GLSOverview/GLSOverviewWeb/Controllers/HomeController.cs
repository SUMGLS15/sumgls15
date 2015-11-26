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

namespace GLSOverviewWeb.Controllers
{
    public enum StatusTypes
    {
        Departed, Arrived, Parked
    }

    public class HomeController : Controller
    {
        private glsoverviewdbEntities _db = new glsoverviewdbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View(_db.cars.ToList());
        }


        //// TODO SK Fjernes, men dele skal bruges i adminregistrations
        //[HttpGet]
        //public ActionResult IndexArchive(DateTime? showDate)
        //{
        //    if (!LoginController.IsAdmin())
        //        return View("~/Views/Login/Index.cshtml");

        //    if (showDate == null)
        //        return View("Index");

        //    var RM = new RegistrationModel();
        //    RM.Cars = _db.cars.ToList();

        //    foreach (var car in RM.Cars)
        //    {
        //        car.Status = (int)StatusTypes.Arrived;
        //    }

        //    var archiveDateStart = showDate.Value.Date;
        //    var archiveDateEnd = showDate.Value.Date.AddDays(1).AddSeconds(-1);

        //    var registrations = _db.registrations.Where(r =>
        //        r.Date >= archiveDateStart &&
        //        r.Date <= archiveDateEnd
        //        ).ToList();

        //    foreach (var registration in registrations)
        //    {
        //        var car = RM.Cars.FirstOrDefault(c => c.Id == registration.CarId);
        //        if (car != null)
        //            car.Status = (int)StatusTypes.Parked;
        //    }

        //    return View("Index", RM);
        //}

        [HttpGet]
        public ActionResult EmployeesLogin(int? carId)
        {
            if (carId == null)
                return RedirectToAction("Index");

            using (_db)
            {
                var employees = (from e in _db.employees
                                 from r in _db.registrations.Where(x => x.EmployeeId == e.Id).DefaultIfEmpty()
                                 orderby r.Date descending
                                 select e).ToList();

                var rm = new RegistrationModel
                {
                    Car = _db.cars.Find(carId),
                    Employees = employees
                };
                
                return View(rm);
            }
        }

        [HttpGet]
        public ActionResult RegisterCarChecked(int? carId, int? empId)
        {
            if (carId == null || empId == null)
                return RedirectToAction("Index");

            using (_db)
            {
                var rm = new RegistrationModel
                {
                    Car = _db.cars.Find(carId),
                    Employee = _db.employees.Find(empId)
                };
                return View(rm);
            }
        }

        [HttpPost]
        public ActionResult RegisterCarChecked(RegistrationModel rm)
        {
            var reg = new registration
            {
                CarId = rm.Car.Id,
                EmployeeId = rm.Employee.Id,
                Date = DateTime.Now,
                Comment = rm.Comment,
                Position = rm.Car.Position
            };
            _db.registrations.Add(reg);

            var car = _db.cars.Find(rm.Car.Id);
            car.Status = (int)StatusTypes.Parked;

            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        // TODO Fix: Is run on EVERY page view, until a car is parked on that day?
        public static void ResetCars()
        {
            using (var _db = new glsoverviewdbEntities())
            {
                var lastAddedReg = _db.registrations.Max(r => r.Date);

                if (lastAddedReg.Date >= DateTime.Today) return;

                foreach (var car in _db.cars)
                {
                    car.Status = (int)StatusTypes.Arrived;
                }

                _db.SaveChanges();
            }
        }
    }
}