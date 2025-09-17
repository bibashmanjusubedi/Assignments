using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        bool running = true;
        while (running == true)
        {
            Console.WriteLine("Choose a program to run");
            Console.WriteLine("1. Grade Calculator 2) Simple Menu System 3) Exit");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    GradeCalculator();
                    running = false;
                    break;

                case 2:
                    SimpleMenuSystem();
                    running = false;
                    break;

                case 3:
                    Console.WriteLine("Exiting");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    continue;
            }
        }
    }

    static void GradeCalculator()
    {
        Console.WriteLine("Opening Grade Calculator");
        string grade;
        while (true)
        {
            Console.Write("Enter the score of student (0-100): ");
            int score = Convert.ToInt32(Console.ReadLine());
            if (score > 90 && score <= 100)
            {
                grade = "A+";
                break;
            }
            else if (score > 80 && score <= 90)
            {
                grade = "A";
                break;
            }
            else if (score > 70 && score <= 80)
            {
                grade = "B";
                break;
            }
            else if (score > 60 && score <= 70)
            {
                grade = " C ";
                break;
            }
            else if (score >= 40 && score <= 60)
            {
                grade = "D";
                break;
            }

            else if (score >= 0 && score < 40)
            {
                grade = "F";
                break;
            }
            else
            {
                Console.WriteLine("Invalid score, please enter a score between 0 and 100.");
                continue;
            }

        }
        Console.WriteLine($"Student has achieveed {grade}");

    }

    static void SimpleMenuSystem()
    {
        Console.WriteLine("Opening Simple Menu System");
        Console.WriteLine("Our Menu ");
        Dictionary<int, string> menu = new Dictionary<int, string>
        {
            { 25, "Tea" },
            { 50, "Coffee" },
            { 20, "Water" },
            { 100, "Cold Drinks" }
        };

        int bill = 0;

        bool ordering = true;
        while (ordering == true)
        {  
            int count = 1;

            foreach (var item in menu)
            {
                Console.WriteLine($"Option-{count}: {item.Value}: Price = Rs.{item.Key}");
                count = count + 1;
            }

            Console.Write("What do you want to order: (1/2/3/4) )? : ");
            int option = Convert.ToInt32(Console.ReadLine());

            Console.Write("How many cups ? : ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            var keys = new List<int>(menu.Keys);

            switch (option)
            {
                case 1:
                    bill = keys[0] * quantity;
                    ordering = false;
                    break;
                
                case 2:
                    bill = keys[1] * quantity;
                    ordering = false;
                    break;
                
                case 3:
                    bill = keys[2] * quantity;
                    ordering = false;
                    break;
                
                case 4:
                    bill = keys[3] * quantity;
                    ordering = false;
                    break;
                
                default:
                    Console.WriteLine("Invalid option");
                    continue;
            }

        }
        Console.WriteLine($"Your bill is Rs.{bill}");
    }

}