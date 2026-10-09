using EmployeeManagementSystem_CodeFirstApproach_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementSystem_CodeFirstApproach_.Controllers
{
    public class AccountController : Controller
    {
        private readonly EmployeeContext db = new EmployeeContext();

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["AccountId"] != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("",
                    "Enter your email and password.");

                return View();
            }

            var account = db.Accounts.FirstOrDefault(
                a => a.Email == email);

            if (account == null ||
                !PasswordHelper.VerifyPassword(
                    password, account.PasswordHash))
            {
                ModelState.AddModelError("",
                    "Invalid email or password.");

                return View();
            }

            Session.Clear();
            Session["AccountId"] = account.AccountId;
            Session["Role"] = account.Role;
            Session["EmployeeId"] = account.EmployeeId;

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string email = model.Email.Trim();

            if (db.Accounts.Any(a => a.Email == email))
            {
                ModelState.AddModelError("Email",
                    "An account with this email already exists.");

                return View(model);
            }

            var employee = new Employee
            {
                EmployeeName = model.EmployeeName.Trim(),
                EmployeeEmail = email,
                EmployeeContact = model.Contact.Trim(),
                EmployeeDesignation = model.Designation.Trim(),
                EmployeeDepatment = model.Department.Trim(),
                EmployeeSalary = 0
            };

            db.Employees.Add(employee);
            db.SaveChanges();

            var account = new Account
            {
                Email = email,
                PasswordHash =
                    PasswordHelper.HashPassword(model.Password),
                Role = "Employee",
                EmployeeId = employee.EmployeeId
            };

            db.Accounts.Add(account);
            db.SaveChanges();

            TempData["Success"] =
                "Registration successful. Please log in.";

            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}