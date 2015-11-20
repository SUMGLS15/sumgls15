using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GLSOverviewWeb.Models;

namespace GLSOverviewWeb.Controllers
{
    public class Login2Controller : Controller
    {
        private glsoverviewdbEntities _db = new glsoverviewdbEntities();

        // GET: Admin
        public ActionResult Index()
        {
            return View("Index"); // as long as this controller is called LoginController2, this wont work
        }

        [HttpPost]
        public ActionResult Index(employee emp)
        {
//            EnsureLoggedIn();

            return RedirectToAction("Index", "Home");
        }

        private void Login(string username, string password)
        {
            //var login = _db.employees
            //               .FirstOrDefault(e => e.EmpNo == username &&
            //                                    e.Password == password);

            //if (login != null)
            //{
                
            //}
        }




        public bool isAdmin()
        {
            var emp = CurrentUser();
            return true;
        }


        /*
        public void EnsureLoggedIn()
        {
            var emp = CurrentUser();
            if (emp == null)
                RedirectToAction("Index", "Login", new { msg = "You need to login"});
        }

        public void EnsureLoggedInAsAdmin()
        {
            var emp = CurrentUser();
            if (emp == null || !emp.Admin)
                RedirectToAction("Index", "Login");
        }
        */

        public employee CurrentUser()
        {
            return (employee)Session["UserAdmin"];
        }
        
    }
}