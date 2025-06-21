using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eproject.Models
{
    public class Exams
    {
        [Key]
        public int ExamId { get; set; }

        [Required(ErrorMessage = "Exam date is required")]
        [Display(Name = "Exam Date")]
        [DataType(DataType.Date)]
        public DateTime ExamDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Exam time is required")]
        [Display(Name = "Time")]
        public string Time { get; set; } = "10:00"; // Default time

        [Required(ErrorMessage = "Course is required")]
        [Display(Name = "Course")]
        public string Course { get; set; } = string.Empty;

        [Required(ErrorMessage = "Student is required")]
        [Display(Name = "Student")]
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        public virtual Candidates Student { get; set; }

        [Display(Name = "Marks Obtained")]
        [Range(0, 100, ErrorMessage = "Marks must be between 0 and 100")]
        public int? MarksObtained { get; set; } // Made nullable
    }
}