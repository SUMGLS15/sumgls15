using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GLSOverviewWeb.Models;

namespace GLSOverviewWeb.Controllers
{
    public class AdminCarsController : Controller
    {
        private glsoverviewdbEntities _db = new glsoverviewdbEntities();

        public ActionResult Index()
        {
            if (!LoginController.IsAdmin())
                return View("~/Views/Login/Index.cshtml");

            using (var _db = new glsoverviewdbEntities())
            {
                var cars = _db.cars.ToList();
                return View(cars);
            }
        }

        [HttpGet]
        public ActionResult Create() {
            if (!LoginController.IsAdmin()) 
                return View("~/Views/Login/Index.cshtml");
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(car car) {
            if (!LoginController.IsAdmin())
                return View("~/Views/Login/Index.cshtml");

            using (_db) {
                _db.cars.Add(car);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!LoginController.IsAdmin())
                return View("~/Views/Login/Index.cshtml");

            if (id == null)
                return RedirectToAction("Index"); // TODO msg?

            using (_db)
            {
                car car = _db.cars.FirstOrDefault(c => c.Id == id);
                int i = car.Id;
                return View(car);
            }
        }

        [HttpPost]
        public ActionResult Edit(car formCar)
        {
            if (!LoginController.IsAdmin())
                return View("~/Views/Login/Index.cshtml");

            using (_db)
            {
                car car = _db.cars.FirstOrDefault(c => c.Id == formCar.Id);

                car.Hauler = formCar.Hauler;
                car.Licenseplate = formCar.Licenseplate;
                car.RouteNo = formCar.RouteNo;
                car.PortNo = formCar.PortNo;

                _db.SaveChanges();

                return RedirectToAction("Index", new { succes = 1 });
            }


        }

        [HttpGet]
        public ActionResult Delete(int id) {
            if (!LoginController.IsAdmin())
                return View("~/Views/Login/Index.cshtml");

            using (_db) {
                car car = _db.cars.Find(id);
                return View(car);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult PostDelete(int id) {
            if (!LoginController.IsAdmin())
                return View("~/Views/Login/Index.cshtml");

            using (_db) {
                car car = _db.cars.Find(id);
                _db.cars.Remove(car);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}