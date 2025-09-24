using System;
using Assignment7;

/// <summary>
/// Student Grade Management System Console Application
/// Features: Add students and grades,Edit grades, compute averages, display reports
/// Includes input validation, error handling, and detailed comments
/// </summary>
class Program
{
    // Maximum number of students
    const int MAX_STUDENTS = 100;
    // Arrays to store student names and their grades
    static Student[] students = new Student[MAX_STUDENTS];// Array to hold student records maximun 100
    static int studentCount = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Student Grade Management System ---");
            Console.WriteLine("1. Add Student and Grade");
            Console.WriteLine("2. Edit Grades");
            Console.WriteLine("3. Display Average Grade");
            Console.WriteLine("4. Display Reports");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");

            string input = Console.ReadLine();
            int choice;
            if (!int.TryParse(input, out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid choice! Please select 1-5.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddStudentAndGrade(); 
                    break;
                case 2: 
                    EditGrades(); 
                    break;
                case 3: 
                    DisplayAverage(); 
                    break;
                case 4: 
                    DisplayReports(); 
                    break;
                case 5: 
                    return; // Exit program
            }
        }
    }

    /// <summary>
    /// Adds a new student to the system with Grade.Validates input.
    /// </summary>
    static void AddStudentAndGrade()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        Console.Write("Enter grade (0-100): ");
        string gradeInput = Console.ReadLine();
        int grade;

        // If input is empty, treat as zero
        if (string.IsNullOrWhiteSpace(gradeInput))
        {
            grade = 0;
        }
        else
        {
            // Parse and validate as usual
            while (!int.TryParse(gradeInput, out grade) || grade < 0 || grade > 100)
            {
                Console.Write("Invalid grade. Enter a number between 0 and 100: ");
                gradeInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(gradeInput))
                {
                    grade = 0;
                    break;
                }
            }
        }

        students[studentCount] = new Student { Name = name, Grade = grade };
        studentCount++;
    }


    /// <summary>
    /// Edit grades for students.
    /// Includes input validation and error handling.
    /// </summary>
    static void EditGrades()
    {
        if (studentCount == 0)
        {
            Console.WriteLine("No students in the system.");
            return;
        }

        Console.Write("Enter the name of the student whose grade you want to edit: ");
        string searchName = Console.ReadLine();
        bool found = false;

        // Search for the student by name
        for (int i = 0; i < studentCount; i++)
        {
            if (students[i] != null && students[i].Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Current grade for {students[i].Name}: {students[i].Grade}");
                Console.Write("Enter new grade (0-100): ");
                int newGrade;
                while (!int.TryParse(Console.ReadLine(), out newGrade) || newGrade < 0 || newGrade > 100)
                {
                    Console.Write("Invalid grade. Enter a number between 0 and 100: ");
                }
                students[i].Grade = newGrade;
                Console.WriteLine($"Grade updated for {students[i].Name}.");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Student not found.");
        }
    }


    /// <summary>
    /// Calculates and displays the average grade.
    /// </summary>
    static void DisplayAverage()
    {
        if (studentCount == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        int total = 0;
        int gradedStudents = 0;

        // Only count valid (non-null) students
        for (int i = 0; i < studentCount; i++)
        {
            if (students[i] != null)
            {
                total += students[i].Grade;
                gradedStudents++;
            }
        }

        if (gradedStudents == 0)
        {
            Console.WriteLine("No grades entered yet.");
            return;
        }

        double average = (double)total / gradedStudents;
        Console.WriteLine($"Average grade of {gradedStudents} students: {average:F2}");
    }


    /// <summary>
    /// Displays a full report of all students and their grades.
    /// Includes grade evaluation via conditionals.
    /// </summary>
    static void DisplayReports()
    {
        if (studentCount == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Console.WriteLine("\n--- Student Grades Report ---");
        for (int i = 0; i < studentCount; i++)
        {
            if (students[i] != null)
            {
                string gradeReport;
                int grade = students[i].Grade;

                // Assign a letter grade
                if (grade >= 90)
                    gradeReport = "A+";
                else if (grade >= 80)
                    gradeReport = "A";
                else if (grade >= 70)
                    gradeReport = "B";
                else if (grade >= 60)
                    gradeReport = "C";
                else if (grade >= 50)
                    gradeReport = "D";
                else
                    gradeReport = "F";

                Console.WriteLine($"Student: {students[i].Name}, Grade: {grade}, Report: {gradeReport}");
            }
        }
    }

}
