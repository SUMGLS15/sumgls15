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

        [HttpGet]
        public ActionResult ParkCarStep1(int? carId)
        {
            if (carId == null)
                return HttpNotFound();

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
        public ActionResult ParkCarStep2(int? carId, int? empId)
        {
            if (carId == null || empId == null)
                return HttpNotFound();

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

        [HttpPost, ActionName("ParkCarStep2")]
        public ActionResult PostParkCarStep2(int? carId, int? empId, string comment)
        {
            if (carId == null || empId == null)
                return HttpNotFound();

            var car = _db.cars.Find(carId);
            if (car == null)
                return HttpNotFound();

            var reg = new registration()
            {
                CarId = car.Id,
                EmployeeId = empId.Value,
                Date = DateTime.Now,
                Comment = comment,
                Position = car.Position
            };
            _db.registrations.Add(reg);
            
            car.Status = (int)StatusTypes.Parked;

            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        // NB: This code is run on EVERY page view, until a car is parked on that day!
        // Should only run once pr. day, but we couldn't fix this in time.
        public static void ResetCars()
        {
            using (var _db = new glsoverviewdbEntities())
            {
                var lastAddedReg = _db.registrations.Max(r => r.Date);
                if (lastAddedReg.Date >= DateTime.Today) return;

                foreach (var car in _db.cars)
                    car.Status = (int)StatusTypes.Arrived;

                _db.SaveChanges();
            }
        }
    }
}