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
    public enum StatusTypes { Out, Home, Delivered }

    public class HomeController : Controller
    {
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
        public ActionResult EmployeesLogin(RegistrationModel RM)
        {
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

                RM.Employees = resList;
                RM.Car = _db.cars.Find(RM.CarID);
                return View(RM);
            }
        }

        [HttpGet]
        public ActionResult RegisterCarChecked(RegistrationModel RM)
        {
            RM.Car = _db.cars.Find(RM.CarID);
            RM.Employee = _db.employees.Find(RM.EmployeeID);
           return View(RM);
        }

        [HttpPost, ActionName("RegisterCarChecked")]
        public ActionResult PostRegisterCarChecked(RegistrationModel RM)
        {
            registration reg = new registration();
            reg.CarId = RM.CarID;
            reg.EmployeeId = RM.EmployeeID;
            reg.Date = DateTime.Now;
            reg.Comment = RM.Comment;
            _db.registrations.Add(reg);

            car car = _db.cars.Find(RM.CarID);
            car.Status = (int) StatusTypes.Delivered;

            _db.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}