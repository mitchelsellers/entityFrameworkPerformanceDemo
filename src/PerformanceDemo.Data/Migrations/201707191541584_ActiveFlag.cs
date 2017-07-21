namespace PerformanceDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActiveFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schools", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schools", "IsActive");
        }
    }
}
