namespace AlgorithmTaskYasserBahnasy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "EmployeeImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "EmployeeImage", c => c.String(nullable: false));
        }
    }
}
