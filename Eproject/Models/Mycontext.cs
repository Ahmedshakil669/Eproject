using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Eproject.Models;// Added namespace for Candidate and other entities



namespace Eproject.Models
{
    public class Mycontext : DbContext
    {
        public Mycontext(DbContextOptions<Mycontext> options) : base(options)
        {
        }

        
        public DbSet<Candidates> Candidates { get; set; }
        public DbSet<Facalty> Faculties { get; set; }
        public DbSet<Batches> Batches { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Exams> Exams { get; set; }
        public DbSet<Enquiry> Enquiry { get; set; }

        public DbSet<Sign_up> Signup { get; set; } 
        public DbSet<Sign_out> Signout { get; set; }
        public object Sign_in { get; internal set; }
    }
}

