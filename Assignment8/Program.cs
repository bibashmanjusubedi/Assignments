using System;

static class MathUtilities
{
    
    // Circle's Area
    public static void CalculateCircleArea()
    {
        Console.Write("Enter the circle radius : ");
        double radius = Convert.ToDouble(Console.ReadLine());
        
        Console.WriteLine($"Area of circle is {Math.PI * radius * radius} square units");
    }

    // Rectangle's Area
    public static void CalculateRectangleArea()
    {
        Console.Write("Enter the rectangle length : ");
        double length = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter the rectangle width : ");
        double width = Convert.ToDouble(Console.ReadLine());
        
        Console.WriteLine($"Area of rectangle is {length * width} units");
    }

    // Triangle's Area
    public static void CalculateTriangleArea()
    {
        Console.Write("Enter the triangle base");
        double baseLength = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter the triangle height");
        double height = Convert.ToDouble(Console.ReadLine());
        
        Console.WriteLine($"Area of triangle is {0.5 * baseLength * height}");
    }

    // PrimeNo
    public static void PrimeNumber()
    {
        Console.Write("Enter a number to check if it's prime: ");
        int number = Convert.ToInt32(Console.ReadLine());
        
        bool isPrime = true;
        
        if (number <= 1)
        {
            isPrime = false;
        }
        else
        {
            for (int i = 2; i <= number-1; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
        }
        if (isPrime)
        {
            Console.WriteLine($"{number} is a prime number.");
        }
        else
        {
            Console.WriteLine($"{number} is not a prime number.");
        }
    }

    //Factorial
    public static void Factorial()
    {
        Console.Write("Enter a number to compute its factorial : ");
        int number = Convert.ToInt32(Console.ReadLine());
        
        long factorial = 1;
        
        for (int i = 1; i <= number; i++)
        {
            factorial *= i;
        }
        
        Console.WriteLine($"Factorial of {number} is {factorial}");
    }
}
class Program
{
    static void Main()
    {
        bool running = true;
        while (running == true)
        {
            Console.WriteLine("Choose a program to run");
            Console.WriteLine("1) AreaCalculator 2)PrimeNumber  3)Factorial 4) Exit");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Choose a shape to calculate area");
                    Console.WriteLine("1) Circle 2) Rectangle 3) Triangle");
                    int shapeOption = Convert.ToInt32(Console.ReadLine());
                    switch (shapeOption)
                    {
                        case 1:
                            MathUtilities.CalculateCircleArea();
                            break;
                        case 2:
                            MathUtilities.CalculateRectangleArea();
                            break;
                        case 3:
                            MathUtilities.CalculateTriangleArea();
                            break;
                        default:
                            Console.WriteLine("Invalid shape option");
                            continue;
                    }
                    running = false;
                    break;

                case 2:
                    MathUtilities.PrimeNumber();
                    running = false;
                    break;

                case 3:
                    MathUtilities.Factorial();
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
}