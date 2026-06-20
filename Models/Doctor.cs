// Models/Doctor.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        [Display(Name = "Doctor Name")]
        public string Name { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public string Department { get; set; } // e.g., OPD, Emergency, Pediatrics

        public string Contact { get; set; }
    }
}