using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace GLSOverviewWeb.Controllers
{

    public enum StatusTypes { Home = 0, Out = 1, Ready = 2 }
    public class HomeController : Controller
    {
        private glsoverviewdbEntities glsDb = new glsoverviewdbEntities();
        
        // GET: Home
        public ActionResult Index()
        {
            using (glsDb)
            {
                var cars = glsDb.employee.ToList();
                return View(cars);
            }
        }
    }
}