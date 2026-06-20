namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Specialization = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Doctors");
        }
    }
}
