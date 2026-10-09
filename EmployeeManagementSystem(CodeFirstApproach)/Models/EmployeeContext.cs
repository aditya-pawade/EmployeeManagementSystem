using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeManagementSystem_CodeFirstApproach_.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("EmployeeContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}