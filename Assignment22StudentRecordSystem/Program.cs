using Assignment22StudentRecordSystem;
using System;

namespace Assignment22StudentRecordsSystem
{
    class Program
    {
        static void Main()
        {
            var config = AppConfig.LoadConfig();
            var manager = new StudentManager(config.CsvFilePath);

            while (true)
            {
                Console.WriteLine("\n--- Student Records System ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Exit");
                Console.Write("Select option: ");
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        AddNewStudent(manager);
                        break;
                    case "2":
                        manager.ListStudents();
                        break;
                    case "3":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid option! Try again.");
                        break;
                }
            }
        }

        static void AddNewStudent(StudentManager manager)
        {
            try
            {
                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter Full Name: ");
                string name = Console.ReadLine() ?? "";
                Console.Write("Enter Age: ");
                int age = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter Grade: ");
                string grade = Console.ReadLine() ?? "";

                manager.AddStudent(new Student { Id = id, FullName = name, Age = age, Grade = grade });
                Console.WriteLine("Student added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
