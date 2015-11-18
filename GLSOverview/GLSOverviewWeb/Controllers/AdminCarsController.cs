using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GLSOverviewWeb.Controllers
{
    public class AdminCarsController : Controller
    {
        private glsoverviewdbEntities _db = new glsoverviewdbEntities();

        // GET: AdminSK
        public ActionResult Index()
        {
            EnsureAdmin();

            using (_db)
            {
                var cars = _db.cars.ToList();
                return View(cars);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            EnsureAdmin();

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
            EnsureAdmin();

            using (_db)
            {
                car car = _db.cars.FirstOrDefault(c => c.Id == formCar.Id );

                car.Hauler = formCar.Hauler;
                car.Licenseplate = formCar.Licenseplate;
                car.RouteNo = formCar.RouteNo;

                _db.SaveChanges();

                return RedirectToAction("Index", new { succes = 1 });
            }

            
        }


        private void EnsureAdmin()
        {
            // Check if logged in as admin
            // If not, redirect to login page

            // for now, does nothing.
        }
    }
}