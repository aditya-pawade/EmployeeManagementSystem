using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementSystem_CodeFirstApproach_.Filters
{
    public class SessionAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _requiredRole;

        public SessionAuthorizeAttribute(string role = null)
        {
            _requiredRole = role;
        }

        protected override bool AuthorizeCore(
            HttpContextBase httpContext)
        {
            if (httpContext.Session == null ||
                httpContext.Session["AccountId"] == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(_requiredRole))
                return true;

            string role =
                httpContext.Session["Role"] as string;

            return string.Equals(
                role,
                _requiredRole,
                StringComparison.OrdinalIgnoreCase);
        }

        protected override void HandleUnauthorizedRequest(
            AuthorizationContext filterContext)
        {
            var session = filterContext.HttpContext.Session;

            if (session == null ||
                session["AccountId"] == null)
            {
                filterContext.Result = new RedirectResult(
                    "~/Account/Login");
                return;
            }

            filterContext.Result = new HttpStatusCodeResult(403);
        }
    }
}