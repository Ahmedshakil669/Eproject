using System.ComponentModel.DataAnnotations;

namespace Eproject.Models
{
    public class Facalty
    {
        [Key]
        public int FacultyId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Faculty Code is required")]
        public int FacultyCode { get; set; }

        [Required(ErrorMessage = "Batch Code is required")]
        public int BatchCode { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan BatchTiming { get; set; } // Changed to TimeSpan

        [Required(ErrorMessage = "Qualification is required")]
        public string Qualification { get; set; } = string.Empty;
    }
}