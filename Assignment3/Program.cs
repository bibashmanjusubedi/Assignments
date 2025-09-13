using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.Write("Enter your age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter your city: ");
        string city = Console.ReadLine();
        Console.Write("Enter your favorite hobby: ");
        string hobby = Console.ReadLine();
        DisplayUserInfo(name,age,city,hobby);
    }
    static void DisplayUserInfo(string name,int age,string city,string hobby)
    {
        int birthYear = DateTime.Now.Year - age;
        Console.WriteLine($"\n User Information: ");
        Console.WriteLine($"Name:   {name}");
        Console.WriteLine($"Age:    {age}");
        Console.WriteLine($"City:   {city}");
        Console.WriteLine($"Hobby:  {hobby}");
        Console.WriteLine($"Birth Year: {birthYear}");
    }
}