using System;
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Simple Calculator");
            Console.WriteLine("Choose an Option (1-6) ");
            Console.WriteLine("1. Addition 2. Subtration 3. Multiplication 4. Division 5. Compound Interest 6. Exit ");
            int option = Convert.ToInt32(Console.ReadLine());
            if (option == 1)
            {
                Console.WriteLine("Addition");
                Addition();
                break;
            }
            else if (option == 2)
            {
                Console.WriteLine("Subtraction");
                Subtraction();
                break;
            }
            else if (option == 3)
            {
                Console.WriteLine("Multiplication");
                Multiplication();
                break;

            }
            else if (option == 4)
            {
                Console.WriteLine("Division");
                Division();
                break;
            }
            else if (option == 5)
            {
                Console.WriteLine("Compound Interest");
                CompoundInterest();
                break;
            }
            else if (option == 6)
            {
                Console.WriteLine("Exiting the program");
                break;
            }
            else
            {
                Console.WriteLine("Invalid Option");
            }

        }
       
        static void Addition()
        {
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int result = num1 + num2;
            Console.WriteLine($"sum = {result}");
        }
        
        static void Subtraction()
        {
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int result = num1 - num2;
            Console.WriteLine($"difference = {result}");

        }

        static void Multiplication()
        {
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int result = num1 * num2;
            Console.WriteLine($"product = {result}");
        }

        static void Division()
        {
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (num2 == 0) Console.WriteLine("Error: Division by zero is not allowed.");
            else
            {
                double result = (double) num1 / num2;
                Console.WriteLine($"result = {result}");
            }
        }

        static void CompoundInterest()
        {
            Console.Write("Enter Principal Amount: ");
            double p = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Rate of Interest: ");
            double r = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Time (in years): ");
            double t = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter number of times interest times interest is compunded per year: ");
            double n = Convert.ToDouble(Console.ReadLine());
            double compoundInterest = p * Math.Pow((1 + r /(100* n)), n * t) - p;
            Console.WriteLine($"Compound Interest = {compoundInterest}");
        }

    }
}