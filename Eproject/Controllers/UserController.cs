using Microsoft.AspNetCore.Mvc;
using Eproject.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Eproject.Controllers
{
    public class UserController : Controller
    {
        private readonly Mycontext _context;

        public UserController(Mycontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Candidates
        public IActionResult Candidate1() => View(_context.Candidates.ToList());

        public IActionResult candidate_create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult candidates_create(Candidates c)
        {
            if (ModelState.IsValid)
            {
                _context.Candidates.Add(c);
                _context.SaveChanges();
                return RedirectToAction("Candidate1");
            }
            return View(c);
        }

        // Faculty
        public IActionResult Facalty() => View(_context.Faculties.ToList());

        [HttpGet]
        public IActionResult Facalty_create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Facalty_create(Facalty f)
        {
            if (ModelState.IsValid)
            {
                _context.Faculties.Add(f);
                _context.SaveChanges();
                return RedirectToAction(nameof(Facalty));
            }
            return View(f);
        }

        // Batch
        public IActionResult Batch() => View(_context.Batches.ToList());

        [HttpGet]
        public IActionResult batch_Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult batch_Create(Batches batch)
        {
            if (ModelState.IsValid)
            {
                _context.Batches.Add(batch);
                _context.SaveChanges();
                return RedirectToAction(nameof(Batch));
            }
            return View(batch);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var batch = _context.Batches.Find(id);
            if (batch == null) return NotFound();
            return View(batch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Batches batch)
        {
            if (id != batch.BatchId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(batch);
                _context.SaveChanges();
                return RedirectToAction(nameof(Batch));
            }
            return View(batch);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var batch = _context.Batches.Find(id);
            if (batch == null) return NotFound();
            return View(batch);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var batch = _context.Batches.Find(id);
            if (batch != null)
            {
                _context.Batches.Remove(batch);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Batch));
        }

        // Courses
        public IActionResult Courses() => View(_context.Courses.ToList());

        [HttpGet]
        public IActionResult create_course() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create_course(Courses course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Course created successfully!";
                return RedirectToAction(nameof(Courses));
            }
            return View(course);
        }
        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCourse(int id, Courses course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Course updated successfully!";
                    return RedirectToAction(nameof(Courses));
                }
                catch (DbUpdateException ex)
                {
                    // Log or handle error
                    ModelState.AddModelError("", "Unable to save changes. Try again.");
                }
            }

            return View(course);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Course deleted successfully!";
            }
            return RedirectToAction(nameof(Courses));
        }

        // Exam
        public IActionResult Exam() => View(
            _context.Exams.Include(e => e.Student).ToList()
        );

        [HttpGet]
        public IActionResult exam_create()
        {
            ViewBag.Courses = _context.Courses.Select(c => c.CourseName).ToList();
            ViewBag.Students = _context.Candidates.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult exam_create(Exams exam)
        {
            if (ModelState.IsValid)
            {
                _context.Exams.Add(exam);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Exam scheduled successfully!";
                return RedirectToAction(nameof(Exam));
            }
            ViewBag.Courses = _context.Courses.Select(c => c.CourseName).ToList();
            ViewBag.Students = _context.Candidates.ToList();
            return View(exam);
        }

        [HttpGet]
        public IActionResult EditExam(int id)
        {
            var exam = _context.Exams.Find(id);
            if (exam == null) return NotFound();
            ViewBag.Courses = _context.Courses.Select(c => c.CourseName).ToList();
            ViewBag.Students = _context.Candidates.ToList();
            return View(exam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditExam(int id, Exams exam)
        {
            if (id != exam.ExamId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(exam);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Exam updated successfully!";
                return RedirectToAction(nameof(Exam));
            }
            ViewBag.Courses = _context.Courses.Select(c => c.CourseName).ToList();
            ViewBag.Students = _context.Candidates.ToList();
            return View(exam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteExam(int id)
        {
            var exam = _context.Exams.Find(id);
            if (exam != null)
            {
                _context.Exams.Remove(exam);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Exam deleted successfully!";
            }
            return RedirectToAction(nameof(Exam));
        }

        // Enquiry
        [HttpGet]
        public IActionResult Enquiry()
        {
            ViewBag.Courses = _context.Courses.Select(c => c.CourseName).ToList();
            return View(_context.Enquiry.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Enquiry(Enquiry enquiry)
        {
            if (ModelState.IsValid)
            {
                _context.Enquiry.Add(enquiry);
                _context.SaveChanges();
                TempData["Success"] = "Enquiry submitted successfully!";
                return RedirectToAction("Enquiry");
            }
            ViewBag.Courses = _context.Courses.Select(c => c.CourseName).ToList();
            return View(enquiry);
        }

        [HttpGet]
        public IActionResult enquiry_create()
        {
            ViewBag.Courses = _context.Courses.Select(c => c.CourseName).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult enquiry_create(Enquiry enquiry)
        {
            if (ModelState.IsValid)
            {
                _context.Enquiry.Add(enquiry);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Enquiry submitted successfully!";
                return RedirectToAction("Enquiry");
            }
            ViewBag.Courses = _context.Courses.Select(c => c.CourseName).ToList();
            return View(enquiry);
        }

        [HttpGet]
        public IActionResult EditEnquiry(int id)
        {
            var enquiry = _context.Enquiry.FirstOrDefault(e => e.EnquiryId == id);
            if (enquiry == null)
            {
                TempData["Error"] = "Enquiry not found!";
                return RedirectToAction("Enquiry");
            }
            ViewBag.Courses = _context.Courses.Select(c => c.CourseName).ToList();
            return View(enquiry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEnquiry(Enquiry enquiry)
        {
            if (ModelState.IsValid)
            {
                _context.Enquiry.Update(enquiry);
                _context.SaveChanges();
                TempData["Success"] = "Enquiry updated successfully!";
                return RedirectToAction("Enquiry");
            }
            ViewBag.Courses = _context.Courses.Select(c => c.CourseName).ToList();
            return View(enquiry);
        }

        [HttpPost]
        public IActionResult DeleteEnquiry(int id)
        {
            var enquiry = _context.Enquiry.FirstOrDefault(e => e.EnquiryId == id);
            if (enquiry != null)
            {
                _context.Enquiry.Remove(enquiry);
                _context.SaveChanges();
                TempData["Success"] = "Enquiry deleted successfully!";
            }
            else
            {
                TempData["Error"] = "Enquiry not found!";
            }
            return RedirectToAction("Enquiry");
        }

        // Sign in/out
        [HttpGet]
        public IActionResult Sign_out()
        {
            return View(); // Show a "Are you sure you want to sign out?" page
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmSignOut()
        {
            // Do actual sign out logic (clear session, cookies, etc.)
            TempData["SuccessMessage"] = "Signed out successfully!";
            return RedirectToAction("Index", "User");
        }


        [HttpGet]
        public IActionResult Sign_in() => View();

        [HttpPost]
        public IActionResult Sign_in(Sign_up model)
        {
            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Signed in successfully!";
                return RedirectToAction("Index", "user");
            }
            return View(model);
        }
    }
}
