namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWardAndBedEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beds",
                c => new
                    {
                        BedId = c.Int(nullable: false, identity: true),
                        BedNumber = c.String(nullable: false),
                        IsOccupied = c.Boolean(nullable: false),
                        WardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BedId)
                .ForeignKey("dbo.Wards", t => t.WardId, cascadeDelete: true)
                .Index(t => t.WardId);
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        WardId = c.Int(nullable: false, identity: true),
                        WardName = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Beds", "WardId", "dbo.Wards");
            DropIndex("dbo.Beds", new[] { "WardId" });
            DropTable("dbo.Wards");
            DropTable("dbo.Beds");
        }
    }
}
