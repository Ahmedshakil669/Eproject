using System;
using System.ComponentModel.DataAnnotations;

namespace Eproject.Models
{
    public class Enquiry
    {
        [Key]
        public int EnquiryId { get; set; }

        [Required]
        public string Name { get; set; } // Added property

        [Required]
        public string Email { get; set; }

        [Required]
        public string CourseInterested { get; set; }

        public DateTime EnquiryDate { get; set; } = DateTime.Now;

        public string Message { get; set; }
    }
}
