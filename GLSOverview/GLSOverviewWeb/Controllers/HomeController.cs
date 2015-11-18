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

    public enum StatusTypes { Home = 0, Out = 1, Delivered = 2 }
    public class HomeController : Controller
    {
        private glsoverviewdbEntities1 glsDb = new glsoverviewdbEntities1();

        private car selectedCar = null;
        private employee selecedEmployee = null;
        private registration newRegistration = null;

        // GET: Home
        public ActionResult Index()
        {
            using (glsDb)

            {
                
                
                
                var cars = glsDb.car.ToList();
                return View(cars);
            }
        }

        public ActionResult EmployeesLogin(int id)
        {
            selectedCar = glsDb.car.Find(id);

            using (glsDb)
            {
                List<employee> resList = new List<employee>();
                var query = from e in glsDb.employee
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

        public ActionResult RegisterCarCheked(int id)
        {
            selecedEmployee = glsDb.employee.Find(id);
            return View();
        }
    }
}