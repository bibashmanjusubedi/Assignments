using System;
using System.Collections.Generic;
using Assignment9;
class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
}

class Program
{
    static void Main()
    {
        bool running = true;
        while (running == true)
        {
            Console.WriteLine("Choose a program to run");
            Console.WriteLine("1) StudentGrade 2)BubbleSortImplementation  3)WeeklyTemperatureTracker 4) Exit");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    StudentGrade();
                    running = false;
                    break;

                case 2:
                    BubbleSortImplementation();
                    running = false;
                    break;

                case 3:
                    WeeklyTemperatureTracker();
                    running = false;
                    break;

                case 4:
                    Console.WriteLine("Exiting");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    continue;
            }
        }
    }

    static void StudentGrade()
    {

        List<Student> students = new List<Student>();
        bool runStudentGrade = true;
        while (runStudentGrade == true)
        {
            Console.WriteLine("Student Grades Program");
            Console.WriteLine("1. Add Student Grade");
            Console.WriteLine("2. View All Grades");
            Console.WriteLine("3. Show Statistics (Highest, Lowest, Average)");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter student name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter grade (0-100): ");
                    int grade;
                    
                    
                    while (!int.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 100)
                    {
                        Console.Write("Invalid grade. Enter a number between 0 and 100: ");
                    }

                    students.Add(new Student { Name = name, Grade = grade });
                    Console.WriteLine("Student grade added.");
                    Console.WriteLine($"No of words in Student = {StringUtilities.CountWords(name)}");
                    Console.WriteLine($"Reversed Name = {StringUtilities.ReverseString(name)}");
                    Console.WriteLine($"Is Palindrome = {StringUtilities.IsPalindrome(name)}");
                    Console.WriteLine($"Student Name without spaces = {StringUtilities.RemoveSpaces(name)}");
                    break;

                case "2":
                    Console.WriteLine("Student Grades");
                    if (students.Count == 0)
                        Console.WriteLine("No records yet.");
                    else
                    {
                        foreach(var student in students)
                        {
                            Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
                        }

                    }
                    break;

                case "3":
                    Console.WriteLine("Statistics");
                    if (students.Count == 0)
                        Console.WriteLine("No records yet.");
                    else
                    {
                        int highest = students.Max(s => s.Grade);
                        int lowest = students.Min(s => s.Grade);
                        double average = students.Average(s => s.Grade);

                        Console.WriteLine($"Highest: {highest}");
                        Console.WriteLine($"Lowest: {lowest}");
                        Console.WriteLine($"Average: {average:F2}");
                    }
                    break;

                case "4":
                    runStudentGrade = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }    
    }

    static void BubbleSortImplementation()
    { 
        Console.WriteLine("Bubble Sort Implementation");
        int[] array = { 64, 34, 25, 12, 22, 11, 90 };
        int n = array.Length;
        Console.WriteLine("Original array: " + string.Join(", ", array));
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Swap temp and arr[i]
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Sorted array: " + string.Join(", ", array));
    }

    static void WeeklyTemperatureTracker()
    {
        string[] days = { "Sunday","Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};
        int[] temperatures = new int[7];

        Console.WriteLine("Weekly Temperature Tracker");
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();

        // Input temperatures
        for (int i = 0; i < 7; i++)
        {
            int temp;
            Console.Write($"Enter temperature for {days[i]}: ");
            while (!int.TryParse(Console.ReadLine(), out temp))
            {
                Console.Write("Invalid input. Enter an integer temperature: ");
            }
            temperatures[i] = temp;
        }

        Console.WriteLine("Temperature for this week");

        for (int i = 0; i < 7; i++)
        {
            Console.Write($"{days[i]} ({temperatures[i]} degree): ");
            Console.WriteLine();
        }

        // Optional: find highest and lowest temperatures
        int maxTemp = temperatures[0], minTemp = temperatures[0];
        string maxDay = days[0], minDay = days[0];

        for (int i = 1; i < 7; i++)
        {
            if (temperatures[i] > maxTemp)
            {
                maxTemp = temperatures[i];
                maxDay = days[i];
            }
            if (temperatures[i] < minTemp)
            {
                minTemp = temperatures[i];
                minDay = days[i];
            }
        }

        Console.WriteLine($"Highest temperature: {maxTemp} degree on {maxDay}");
        Console.WriteLine($"Lowest temperature: {minTemp} degree on {minDay}");
    }

}
    


