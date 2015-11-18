using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.UI.WebControls;

namespace GLSOverviewWeb.Controllers
{
    public enum StatusTypes { Home, Out, Delivered }

    public class HomeController : Controller
    {
        private glsoverviewdbEntities _db = new glsoverviewdbEntities();

        private car selectedCar = null;
        private employee selecedEmployee = null;
        private registration newRegistration = null;

        // GET: Home
        public ActionResult Index()
        {
            using (_db)
            {   
                var cars = _db.cars.ToList();
                return View(cars);
            }
        }

        public ActionResult EmployeesLogin(int id)
        {
            selectedCar = _db.cars.Find(id);

            using (_db)
            {
                List<employee> resList = new List<employee>();
                var query = from e in _db.employees
                            orderby e.Name ascending 
                            select e;
                foreach (var emp in query)
                {
                    resList.Add(emp);
                }
                ViewBag.Car = selectedCar;
                return View(resList);
            }
        }

        public ActionResult RegisterCarChecked(int id)
        {
            selecedEmployee = _db.employees.Find(id);
            return View();
        }
    }
}