namespace EmployeeManagementSystem_CodeFirstApproach_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        EmployeeAadharId = c.Int(nullable: false),
                        EmployeePancard = c.Int(nullable: false),
                        EmployeeDesignation = c.String(),
                        EmployeeDepatment = c.String(),
                        EmployeeSalary = c.Double(nullable: false),
                        EmployeeEmail = c.String(),
                        EmployeeContact = c.Int(nullable: false),
                        EmployeeAddress = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
