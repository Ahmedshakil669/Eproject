using System;
using System.ComponentModel.DataAnnotations;

namespace Eproject.Models
{
    public class Candidates
    {
        [Key]
        public int CandidateId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int IsOnBreak { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal FineAmount { get; set; }

        [Required]
        public string PaymentMode { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan BatchTiming { get; set; }

        [Required]
        public DateOnly RegistrationDate { get; set; }
    }
}
