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

                _db.SaveChanges();

                return RedirectToAction("Index", new { succes = 1 });
            }


        }

    }
}