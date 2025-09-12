// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        string name = "Bibash";
        char grade = 'A';
        float gpa = 4.0f;

        DateTime dob = new DateTime(1999, 02, 07); // my date of birth
        DateTime today = DateTime.Today;           // current date
        TimeSpan age = today - dob;                // subtract dates to get age

        DisplayStudentInfo(name, grade, gpa, age); // method call to display student info
    }

    public static void DisplayStudentInfo(string name, char grade, float gpa, TimeSpan age)
    {
        Console.WriteLine($"Student {name} who is {age.Days} Days old has scored grade {grade} with GPA {gpa}.");
    }
}
