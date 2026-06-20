// Models/Ward.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Ward
    {
        [Key]
        public int WardId { get; set; }

        [Required]
        [Display(Name = "Ward Name")]
        public string WardName { get; set; } // e.g., General, ICU, Maternity, Pediatric

        [Required]
        [Display(Name = "Total Capacity")]
        public int Capacity { get; set; }
    }
}