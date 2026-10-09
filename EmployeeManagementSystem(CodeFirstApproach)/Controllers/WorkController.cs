using EmployeeManagementSystem_CodeFirstApproach_.Filters;
using EmployeeManagementSystem_CodeFirstApproach_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementSystem_CodeFirstApproach_.Controllers
{
    [SessionAuthorize]
    public class WorkController : Controller
    {
        private readonly EmployeeContext db =
            new EmployeeContext();

        // Admin employee list with search.
        [SessionAuthorize("Admin")]
        public ActionResult Index(string search)
        {
            var employees = db.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                employees = employees.Where(e =>
                    e.EmployeeName.Contains(search) ||
                    e.EmployeeEmail.Contains(search) ||
                    e.EmployeeDesignation.Contains(search));
            }

            ViewBag.Search = search;

            return View(employees
                .OrderBy(e => e.EmployeeName)
                .ToList());
        }

        // Employee views their own record only.
        public ActionResult MyProfile()
        {
            if (Session["Role"] as string == "Admin")
                return RedirectToAction("Index");

            int employeeId =
                Convert.ToInt32(Session["EmployeeId"]);

            var employee = db.Employees.Find(employeeId);

            if (employee == null)
                return HttpNotFound();

            return View("Details", employee);
        }

        // View one employee. Employees may view only themselves.
        public ActionResult Details(int id)
        {
            var employee = db.Employees.Find(id);

            if (employee == null)
                return HttpNotFound();

            if (Session["Role"] as string != "Admin")
            {
                int myId =
                    Convert.ToInt32(Session["EmployeeId"]);

                if (employee.EmployeeId != myId)
                    return new HttpStatusCodeResult(403);
            }

            return View(employee);
        }

        [SessionAuthorize("Admin")]
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View(new Employee());
        }

        [SessionAuthorize("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            db.Employees.Add(employee);
            db.SaveChanges();

            TempData["Success"] =
                "Employee created successfully.";

            return RedirectToAction("Index");
        }

        [SessionAuthorize("Admin")]
        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            var employee = db.Employees.Find(id);

            if (employee == null)
                return HttpNotFound();

            return View(employee);
        }

        [SessionAuthorize("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            var existing = db.Employees.Find(employee.EmployeeId);

            if (existing == null)
                return HttpNotFound();

            // Update permitted fields explicitly.
            existing.EmployeeName = employee.EmployeeName;
            existing.EmployeeAadharId = employee.EmployeeAadharId;
            existing.EmployeePancard = employee.EmployeePancard;
            existing.EmployeeDesignation = employee.EmployeeDesignation;
            existing.EmployeeDepatment = employee.EmployeeDepatment;
            existing.EmployeeSalary = employee.EmployeeSalary;
            existing.EmployeeEmail = employee.EmployeeEmail;
            existing.EmployeeContact = employee.EmployeeContact;
            existing.EmployeeAddress = employee.EmployeeAddress;

            db.SaveChanges();

            TempData["Success"] =
                "Employee updated successfully.";

            return RedirectToAction("Index");
        }

        [SessionAuthorize("Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = db.Employees.Find(id);

            if (employee == null)
                return HttpNotFound();

            // Avoid deleting an employee that still has a login.
            bool hasAccount = db.Accounts.Any(
                a => a.EmployeeId == id);

            if (hasAccount)
            {
                TempData["Error"] =
                    "This employee has a login account. " +
                    "Deactivate the account before deleting the record.";

                return RedirectToAction("Index");
            }

            db.Employees.Remove(employee);
            db.SaveChanges();

            TempData["Success"] =
                "Employee deleted successfully.";

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}