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
            return View();
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
                                        where e.EmpNo == emp.EmpNo
                                        select e).FirstOrDefault();
            if (login != null && login.Admin == true) {
                return RedirectToAction("Index", "Admin", emp);
            }
            else {
                userSession = null;
                return View();
            }
        }
    }
}