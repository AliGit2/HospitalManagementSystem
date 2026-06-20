// Models/Bed.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Bed
    {
        [Key]
        public int BedId { get; set; }

        [Required]
        [Display(Name = "Bed Number")]
        public string BedNumber { get; set; } // e.g., Bed-A1, Bed-A2

        [Display(Name = "Is Occupied?")]
        public bool IsOccupied { get; set; } = false;

        // Foreign Key Linking to Ward
        [Required]
        public int WardId { get; set; }

        [ForeignKey("WardId")]
        public virtual Ward Ward { get; set; }
    }
}