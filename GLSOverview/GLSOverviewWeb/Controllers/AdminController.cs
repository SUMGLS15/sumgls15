using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GLSOverviewWeb.Controllers
{
    public class AdminController : Controller
    {
        glsoverviewdbEntities1 db = new glsoverviewdbEntities1();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(employee emp) {
        //    try {
        //        Session["UserAdmin"] = emp.EmpNo;
        //    }
        //    catch (Exception e) {
        //        Console.WriteLine(e);
        //    }

        //    string userSession = (string)Session["UserAdmin"];
        //    employee login = (employee)(from e in db.employee
        //                              where e.EmpNo == emp.EmpNo
        //                              select e).FirstOrDefault();
        //    if (login != null && login.Admin == true) {
        //        return );
        //    }
        //    else {
        //        return View();
        //    }
        //}
    }
}