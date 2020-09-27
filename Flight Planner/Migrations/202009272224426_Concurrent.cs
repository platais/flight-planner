namespace Flight_Planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Concurrent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "RowVersion");
        }
    }
}
