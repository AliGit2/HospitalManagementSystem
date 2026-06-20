// Models/HospitalContext.cs
using System.Data.Entity;

namespace HospitalManagementSystem.Models
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
            : base("HospitalConnection")
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Bed> Beds { get; set; }

        // Added for Step 19: Central Admission Entity
        public DbSet<Admission> Admissions { get; set; }
    }
}