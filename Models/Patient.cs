// Models/Patient.cs

using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Contact { get; set; }

        public string Address { get; set; }

        public string MedicalHistory { get; set; }
    }
}