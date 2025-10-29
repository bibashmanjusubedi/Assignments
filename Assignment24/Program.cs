using Assignment24;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using var db = new SchoolContext();

        var student1 = new Student { Name = "Bibash", Grade = "B", Enrollment = DateTime.Now };
        db.Students.Add(student1);

        var student2 = new Student { Name = "Hasan", Grade = "A", Enrollment = DateTime.Now };
        db.Students.Add(student2);

        var student3 = new Student { Name = "Nishil", Grade = "A", Enrollment = DateTime.Now };
        db.Students.Add(student3);
        db.SaveChanges();
        Console.WriteLine("Added students");

        // Query students
        Console.WriteLine("All students:");
        foreach (var s in db.Students.ToList())
            Console.WriteLine($"{s.Id}: {s.Name}, Grade->{s.Grade}, Enrolled->{s.Enrollment}");

        // Query by criteria
        var query = db.Students.Where(s => s.Grade == "A");
        Console.WriteLine("Students with grade A:");
        foreach (var s in query)
            Console.WriteLine($"{s.Id}: {s.Name}");

        // Update student
        var studentToUpdate = db.Students.FirstOrDefault();
        if (studentToUpdate != null)
        {
            studentToUpdate.Grade = "B+";
            db.SaveChanges();
            Console.WriteLine("Updated student grade.");
        }

        // Delete student
        var studentToDelete = db.Students.FirstOrDefault();
        if (studentToDelete != null)
        {
            db.Students.Remove(studentToDelete);
            db.SaveChanges();
            Console.WriteLine("Deleted student.");
        }
    }
}
