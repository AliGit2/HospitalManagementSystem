// Models/Admission.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Admission
    {
        [Key]
        public int AdmissionId { get; set; }

        [Required]
        [Display(Name = "Admission Date")]
        [DataType(DataType.Date)]
        public DateTime AdmissionDate { get; set; } = DateTime.Today;

        [Display(Name = "Discharge Date")]
        [DataType(DataType.Date)]
        public DateTime? DischargeDate { get; set; }

        [Display(Name = "Treatment Summary")]
        public string TreatmentSummary { get; set; }

        // --- FOREIGN KEYS ---
        [Required]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        [Required]
        [Display(Name = "Attending Doctor")]
        public int DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }

        [Required]
        [Display(Name = "Assigned Bed")]
        public int BedId { get; set; }

        [ForeignKey("BedId")]
        public virtual Bed Bed { get; set; }
    }
}