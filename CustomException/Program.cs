// Custom Exception : User Defined Exception
// Just like user defined functions and classes, we can also create our own custom exceptions
// in many software applicationsm we need to create our custom exceptions for errors and cases that are not handled by built in exceptions
// Use cases : Eg: In Banking System: Age must be at least 18 to open an account, Insufficient funds exception when withdroawal amount is greater than present in Account
// Advantages: Specific error handling, Debugging made easier, Granular Control(offer precise control over catching and logging user friendly error messages
// Disadvangtes : Increases code base size,learning curve: new team members need to understand custom exception hierarchy and workflow
// Inherits from the base Exception class
using System;

// Define the custom exception class
public class MyCustomException : Exception
{
    public MyCustomException() { }

    public MyCustomException(string message) : base(message) { }

    public MyCustomException(string message, Exception inner) : base(message, inner) { }
}

// Using the custom exception in practice
public class CustomExceptionDemo
{
    public void DoSomething(int number)
    {
        if (number < 0)
        {
            throw new MyCustomException("Number cannot be negative.");
        }
        Console.WriteLine("Number is valid.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var demo = new CustomExceptionDemo();
        try
        {
            demo.DoSomething(-5);
        }
        catch (MyCustomException ex)
        {
            Console.WriteLine($"Custom Exception caught: {ex.Message}");
        }
    }
}
