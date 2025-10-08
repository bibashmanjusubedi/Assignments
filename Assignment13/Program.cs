using System;

public class Employee
{
    // Private fields
    private string _name;
    private int _age;
    private decimal _salary;

    // Name property with validation
    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty.");
            _name = value;
        }
    }
    
    // Age property with validation
    public int Age
    {
        get { return _age; }
        set
        {
            if (value < 18 || value > 65)
                throw new ArgumentOutOfRangeException("Age must be between 18 and 65");
            _age = value;
        }
    }

    // Salary preperty with validation
    public decimal Salary
    {
        get { return _salary; }
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("Salary must be positive");
            _salary = value;
        }
    }

    // Yearly Bonus method
    public decimal CalculateYearlyBonus()
    {
        return Salary * 0.10m;
    }
}

class Program
{
    static void Main()
    {
        Employee person = new Employee();

        person.Name = "John Doe";
        person.Age = 25;
        person.Salary = 60000;

        Console.WriteLine($"{person.Name}'s salary is {person.Salary} and his yearly bonus is {person.CalculateYearlyBonus()}");
    }
}
