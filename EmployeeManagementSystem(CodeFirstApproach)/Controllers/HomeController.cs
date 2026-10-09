using EmployeeManagementSystem_CodeFirstApproach_.Filters;
using EmployeeManagementSystem_CodeFirstApproach_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementSystem_CodeFirstApproach_.Controllers
{
    public class HomeController : Controller
    {
        [SessionAuthorize]
        public ActionResult Index()
        {
            if (Session["Role"] as string == "Admin")
            {
                using (var db = new EmployeeContext())
                {
                    ViewBag.EmployeeCount = db.Employees.Count();
                }
            }

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}