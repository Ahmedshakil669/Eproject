using System;
using System.ComponentModel.DataAnnotations;
namespace Eproject.Models
{
    public class Sign_out
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool CheckMeOut { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
