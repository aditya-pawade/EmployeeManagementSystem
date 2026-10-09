namespace EmployeeManagementSystem_CodeFirstApproach_.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeManagementSystem_CodeFirstApproach_.Models.EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EmployeeManagementSystem_CodeFirstApproach_.Models.EmployeeContext";
        }

        protected override void Seed(EmployeeManagementSystem_CodeFirstApproach_.Models.EmployeeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
