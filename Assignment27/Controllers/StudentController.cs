using Microsoft.AspNetCore.Mvc;
using Assignment27.Models;
using System.Collections.Generic;
using System.Linq;

namespace Assignment27.Controllers
{
    public class StudentController : Controller
    {
        // Simulated data store (in-memory list)
        private static List<Student> students = new List<Student>();

        // GET: /Student/Index
        public IActionResult Index()
        {
            // Pass the list of students to the view
            return View(students);
        }

        // GET: /Student/Details/5
        public IActionResult Details(int id)
        {
            // Find student by id
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return View(student);
        }

        // GET: /Student/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                // Simple Id assignment: increment based on count
                student.Id = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1;

                // Add student to the list
                students.Add(student);

                // Redirect to the Index action after successful creation
                return RedirectToAction("Index");
            }
            // If model validation fails, show form with validation messages
            return View(student);
        }

    }
}
