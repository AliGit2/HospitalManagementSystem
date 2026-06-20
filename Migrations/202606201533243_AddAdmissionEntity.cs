namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdmissionEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admissions",
                c => new
                    {
                        AdmissionId = c.Int(nullable: false, identity: true),
                        AdmissionDate = c.DateTime(nullable: false),
                        DischargeDate = c.DateTime(),
                        TreatmentSummary = c.String(),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        BedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdmissionId)
                .ForeignKey("dbo.Beds", t => t.BedId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.BedId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admissions", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Admissions", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Admissions", "BedId", "dbo.Beds");
            DropIndex("dbo.Admissions", new[] { "BedId" });
            DropIndex("dbo.Admissions", new[] { "DoctorId" });
            DropIndex("dbo.Admissions", new[] { "PatientId" });
            DropTable("dbo.Admissions");
        }
    }
}
