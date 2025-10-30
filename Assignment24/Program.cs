using Assignment24;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        using var db = new SchoolContext();

        // Clear existing data (optional, ensure for demo repeatability)
        db.Grades.RemoveRange(db.Grades);
        db.Students.RemoveRange(db.Students);
        db.Courses.RemoveRange(db.Courses);
        db.SaveChanges();

        // Seed Courses
        var math = new Course { Title = "Math" };
        var science = new Course { Title = "Science" };
        db.Courses.AddRange(math, science);
        db.SaveChanges();

        // Seed Students with Courses and Grades
        var student1 = new Student
        {
            Name = "Bibash",
            Enrollment = DateTime.Now,
            Courses = { math, science },
            Grades =
            {
                new Grade { GradeValue = "85" },
                new Grade { GradeValue = "90" }
            }
        };
        var student2 = new Student
        {
            Name = "Hasan",
            Enrollment = DateTime.Now,
            Courses = { math },
            Grades =
            {
                new Grade { GradeValue = "95" }
            }
        };
        var student3 = new Student
        {
            Name = "Nishil",
            Enrollment = DateTime.Now,
            Courses = { science },
            Grades =
            {
                new Grade { GradeValue = "88" }
            }
        };

        db.Students.AddRange(student1, student2, student3);
        db.SaveChanges();
        Console.WriteLine("Seeded students, courses, grades.");

        // 1. Students enrolled in a specific course (e.g. "Math")
        string courseName = "Math";
        var studentsInCourse = db.Courses
            .Include(c => c.Students)
            .Where(c => c.Title == courseName)
            .SelectMany(c => c.Students)
            .Distinct()
            .ToList();

        Console.WriteLine($"\nStudents enrolled in {courseName}:");
        foreach (var s in studentsInCourse)
        {
            Console.WriteLine($"- {s.Name}");
        }

        string courseName2 = "Science";
        var studentsInCourse2 = db.Courses
            .Include(c => c.Students)
            .Where(c => c.Title == courseName2)
            .SelectMany(c => c.Students)
            .Distinct()
            .ToList();

        Console.WriteLine($"\nStudents enrolled in {courseName2}:");
        foreach (var s in studentsInCourse2)
        {
            Console.WriteLine($"- {s.Name}");
        }


        // 2. Average grades per course with null checks
        var avgGrades = db.Courses
            .Include(c => c.Students)
                .ThenInclude(st => st.Grades)
            .AsEnumerable()  // Switch to client-side evaluation from here on
            .Select(c => new
            {
                Course = c.Title,
                AverageGrade = (c.Students ?? new List<Student>())
                    .SelectMany(st => st.Grades ?? new List<Grade>())
                    .Where(g => !string.IsNullOrEmpty(g.GradeValue))
                    .Select(g => ParseGrade(g.GradeValue))
                    .DefaultIfEmpty(0)
                    .Average()
            })
            .ToList();


        Console.WriteLine("\nAverage grades per course:");
        foreach (var item in avgGrades)
        {
            Console.WriteLine($"{item.Course}: {item.AverageGrade:F2}");
        }

        var studentsGpa = db.Students
            .Include(s => s.Grades)
            .AsEnumerable()  // Switch to client evaluation here
            .Select(s => new
            {
                Student = s,
                GPA = (s.Grades ?? new List<Grade>())
                    .Where(g => !string.IsNullOrEmpty(g.GradeValue))
                    .Select(g => ParseGrade(g.GradeValue))
                    .DefaultIfEmpty(0)
                    .Average()
            })
            .OrderByDescending(s => s.GPA)
            .ToList();


        var highestGpa = studentsGpa.FirstOrDefault()?.GPA ?? 0;
        var topStudents = studentsGpa.Where(s => s.GPA == highestGpa).Select(s => s.Student);

        Console.WriteLine("\nStudents with highest GPA:");
        foreach (var s in topStudents)
        {
            Console.WriteLine($"{s.Name} - GPA: {highestGpa:F2}");
        }
    }

    private static int ParseGrade(string grade)
    {
        if (string.IsNullOrEmpty(grade))
            return 0;

        return int.TryParse(grade, out int val) ? val : 0;
    }
}
