using System.ComponentModel.DataAnnotations;

namespace Eproject.Models
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course code is required")]
        [StringLength(20, ErrorMessage = "Course code cannot exceed 20 characters")]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course fee is required")]
        [Range(1000, 100000, ErrorMessage = "Fee must be between 1,000 and 100,000")]
        [Display(Name = "Fee")]
        [DataType(DataType.Currency)]
        public int CourseFee { get; set; } = 10000;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course duration is required")]
        [Range(1, 36, ErrorMessage = "Duration must be between 1 and 36 months")]
        [Display(Name = "Duration (months)")]
        public int CourseLenth { get; set; } = 3;
    }
}