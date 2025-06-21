using System;
using System.ComponentModel.DataAnnotations;
namespace Eproject.Models
{

    public class Sign_up
    {
        [Key] 
        public int Id { get; set; }  // Primary key

        public string Email { get; set; }
        public string Password { get; set; }
        public bool CheckMeOut { get; set; }
    }
}
