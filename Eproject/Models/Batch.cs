// Models/Batches.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace Eproject.Models
{
    public class Batches
    {
        [Key]
        public int BatchId { get; set; }

        [Required(ErrorMessage = "Batch name is required")]
        [Display(Name = "Batch Name")]
        public string BatchName { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [Display(Name = "Course")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Today.AddMonths(3);

        [Required(ErrorMessage = "Timing is required")]
        public string Timing { get; set; }

        [Required(ErrorMessage = "Faculty name is required")]
        [Display(Name = "Faculty")]
        public string FacultyName { get; set; }

        [Required(ErrorMessage = "Capacity is required")]
        [Range(1, 100, ErrorMessage = "Capacity must be between 1 and 100")]
        public int Capacity { get; set; } = 20;
    }
}