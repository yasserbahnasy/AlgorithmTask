namespace AlgorithmTaskYasserBahnasy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        HiringDate = c.DateTime(nullable: false),
                        EmployeeImage = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Departs", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departs");
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropTable("dbo.Employees");
        }
    }
}
