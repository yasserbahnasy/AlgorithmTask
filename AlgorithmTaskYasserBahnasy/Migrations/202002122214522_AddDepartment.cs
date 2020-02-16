namespace AlgorithmTaskYasserBahnasy.Migrations
{

    using System;
    using System.Data.Entity.Migrations;

    public partial class AddDepartment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departs",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    DepName = c.String(nullable: false),
                    ManagerId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.ManagerId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Departs", "ManagerId", "dbo.AspNetUsers");
            DropIndex("dbo.Departs", new[] { "ManagerId" });
            DropTable("dbo.Departs");
        }
    }
}
