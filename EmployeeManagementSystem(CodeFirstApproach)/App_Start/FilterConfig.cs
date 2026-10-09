using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementSystem_CodeFirstApproach_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
