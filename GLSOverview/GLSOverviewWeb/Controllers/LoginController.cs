using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GLSOverviewWeb.Controllers
{
    public class LoginController : Controller
    {
        private glsoverviewdbEntities db = new glsoverviewdbEntities();
        // GET: Admin
        public ActionResult Index() {
            return View("~/Views/Login/Index.cshtml");
        }

        [HttpPost]
        public ActionResult Index(employee emp) {
            try {
                Session["UserAdmin"] = emp.EmpNo;
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

            string userSession = (string)Session["UserAdmin"];
            var login = (from e in db.employees
                                        where e.EmpNo == emp.EmpNo && e.Password == emp.Password
                                        select e).FirstOrDefault();
            if (login != null && login.Admin == true) {
                TempData["adminUser"] = login;
                return RedirectToAction("Index", "Admin");
            }
            else {
                userSession = null;
                return View();
            }
        }
    }
}