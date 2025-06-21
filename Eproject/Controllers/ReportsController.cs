using Eproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Eproject.Controllers
{
    public class ReportsController : Controller
    {
        private readonly Mycontext _context;
        public IActionResult Index()
        {
            return View();
        }

        public ReportsController(Mycontext context)
        {
            _context = context;
        }


        // ---------------- STUDENT REPORTS ------------------

        public IActionResult StudentDetailByMonthYear(int? month, int? year)
        {
            var data = _context.Candidates
                .Where(c => (!month.HasValue || c.RegistrationDate.Month == month)
                         && (!year.HasValue || c.RegistrationDate.Year == year))
                .ToList();

            return View(data);
        }

        public IActionResult StudentOnBreak() // Instead of StudentCompletionStatus
        {
            var data = _context.Candidates
                .Where(c => c.IsOnBreak == 1)
                .ToList();

            return View(data);
        }

        public IActionResult StudentByTiming(TimeSpan timing)
        {
            var data = _context.Candidates
                .Where(c => c.BatchTiming == timing)
                .ToList();

            return View(data);
        }

        public IActionResult FineDetails()
        {
            var data = _context.Candidates
                .Where(c => c.FineAmount > 0)
                .ToList();

            return View(data);
        }

        public IActionResult PaymentModes()
        {
            var data = _context.Candidates
                .GroupBy(c => c.PaymentMode)
                .Select(group => new
                {
                    PaymentMode = group.Key,
                    Count = group.Count()
                })
                .ToList();

            return View(data);
        }

        // ---------------- EXAM REPORT ------------------

        public IActionResult ExamReport()
        {
            var data = _context.Exams
                .Include(e => e.Student)
                .ToList();

            return View(data);
        }

        // ---------------- BATCH REPORTS ------------------

        public IActionResult EndingBatches()
        {
            var data = _context.Batches
                .Where(b => b.EndDate < DateTime.Today)
                .ToList();

            return View(data);
        }

        public IActionResult StartingBatches()
        {
            var data = _context.Batches
                .Where(b => b.StartDate >= DateTime.Today)
                .ToList();

            return View(data);
        }

        public IActionResult StudentsInBatch(string timing)
        {
            var data = _context.Candidates
                .Where(c => c.BatchTiming.ToString() == timing)
                .ToList();

            return View(data);
        }

        public IActionResult TestReportsByTiming(TimeSpan timing)
        {
            var data = _context.Exams
                .Include(e => e.Student)
                .Where(e => e.Student.BatchTiming == timing)
                .ToList();

            return View(data);
        }
    }
}
