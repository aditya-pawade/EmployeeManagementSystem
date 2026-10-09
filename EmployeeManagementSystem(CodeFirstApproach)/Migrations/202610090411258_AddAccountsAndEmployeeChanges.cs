namespace EmployeeManagementSystem_CodeFirstApproach_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountsAndEmployeeChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 150),
                        PasswordHash = c.String(nullable: false),
                        Role = c.String(nullable: false, maxLength: 20),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.AccountId);
            
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Employees", "EmployeeAadharId", c => c.String(maxLength: 12));
            AlterColumn("dbo.Employees", "EmployeePancard", c => c.String(maxLength: 10));
            AlterColumn("dbo.Employees", "EmployeeDesignation", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Employees", "EmployeeDepatment", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Employees", "EmployeeSalary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Employees", "EmployeeEmail", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Employees", "EmployeeContact", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employees", "EmployeeAddress", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "EmployeeAddress", c => c.String());
            AlterColumn("dbo.Employees", "EmployeeContact", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "EmployeeEmail", c => c.String());
            AlterColumn("dbo.Employees", "EmployeeSalary", c => c.Double(nullable: false));
            AlterColumn("dbo.Employees", "EmployeeDepatment", c => c.String());
            AlterColumn("dbo.Employees", "EmployeeDesignation", c => c.String());
            AlterColumn("dbo.Employees", "EmployeePancard", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "EmployeeAadharId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String());
            DropTable("dbo.Accounts");
        }
    }
}
