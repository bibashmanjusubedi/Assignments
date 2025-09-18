using System;
class Program
{
    static void Main()
    {
        bool running = true;
        while (running == true)
        {
            Console.WriteLine("Choose a program to run");
            Console.WriteLine("1. Multiplication Table 2) Number Guessing Game 3) Sum of Even Numbers(1-100) 4) Pattern Priting 5) Exit");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    MultiplicationTable();
                    running = false;
                    break;

                case 2:
                    NumberGuessingGame();
                    running = false;
                    break;

                case 3:
                    SumOfEvenNumbers();
                    running = false;
                    break;

                case 4:
                    PatternPrinting();
                    running = false;
                    break;

                case 5:
                    Console.WriteLine("Exiting");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    continue;
            }
        }
    }

    static void MultiplicationTable()
    {
        Console.WriteLine("Opening Multiplication Table Program");
        Console.WriteLine("Press any key to start...");
        Console.ReadLine();
        
        for (int i = 1; i <= 10; i++)  // iterate through numbers 1 to 10
        {
            Console.WriteLine($" Table of {i}: ");

            for (int j = 1; j <= 10; j++)  // Multiplication no from 1 to 10
            {
                Console.WriteLine($"{i} x {j} = {i * j}");
            }

            Console.WriteLine(); // Blank line between tables
        }
    }

    static void NumberGuessingGame()
    {
        Console.WriteLine("Opening Number Guessing Game Program");
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();

        Random random = new Random();
        int numberToGuess = random.Next(1, 101); // Random number between 1 and 100
        int userGuess = 0;
        int attempts = 0;
        while (userGuess != numberToGuess)
        {
            Console.Write("Enter your guess (1-100): ");
            userGuess = Convert.ToInt32(Console.ReadLine());
            attempts++;
            if (userGuess < numberToGuess)
            {
                Console.WriteLine("Too low! Try again.");
            }
            else if (userGuess > numberToGuess)
            {
                Console.WriteLine("Too high! Try again.");
            }
            else
            {
                Console.WriteLine($"Congratulations! You've guessed the number {numberToGuess} in {attempts} attempts.");
            }
        }
    }

    static void SumOfEvenNumbers()
    {
        Console.WriteLine("Opening Sum of Even Numbers Program");
        Console.WriteLine("Press any key to start...");
        Console.ReadLine();

        int sum = 0;
        for (int i = 1; i <= 100; i++)
        {
            if (i % 2 == 0)
            {
                sum += i;
            }
        }
        Console.WriteLine($"The sum of even numbers from 1 to 100 is: {sum}");
    }

    static void PatternPrinting()
    {
        Console.WriteLine("Opening Pattern Printing Program");
        Console.WriteLine("Press any key to start...");
        Console.ReadLine();

        Console.WriteLine("Choose a shape to print :");
        Console.WriteLine("1. Triangle 2. Rectangle 3.Diamond ");
        
        int option = Convert.ToInt32(Console.ReadLine());
        
        switch (option)
        {
            case 1:
                Console.WriteLine("Triangle Pattern:");
                for (int i = 1; i <= 3; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write(" * ");
                    }
                    Console.WriteLine();
                }
                break;

            case 2:
                Console.WriteLine("Rectangle Pattern:");
                for (int i = 1; i <= 4; i++)
                {
                    for (int j = 1; j <= 6; j++)
                    {
                        Console.Write("* ");
                    }
                    Console.WriteLine();
                }
                break;

            case 3:
                Console.WriteLine("Diamond Pattern:");
                int rows = 5;
                for (int i = 1; i <= rows; i++)
                {
                    for (int j = i; j < rows; j++)
                        Console.Write(" ");
                    for (int k = 1; k <= (2 * i - 1); k++)
                        Console.Write("*");
                    Console.WriteLine();
                }
                for (int i = rows - 1; i >= 1; i--)
                {
                    for (int j = rows; j > i; j--)
                        Console.Write(" ");
                    for (int k = 1; k <= (2 * i - 1); k++)
                        Console.Write("*");
                    Console.WriteLine();
                }
                break;

            default:
                Console.WriteLine("Invalid option");
                break;
        }



    }


}