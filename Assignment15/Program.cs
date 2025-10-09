// Abstract Class Vehicle with Derived Classes Car, Motorcycle, and Truck
public abstract class Vehicle
{
    public string Name { get; set; }
    public Vehicle(string name)
    {
        Name = name;
    }
    public abstract void Drive();
}

public class Car : Vehicle
{
    public Car(string name) : base(name) { }
    public override void Drive()
    {
        Console.WriteLine($"{Name} (Car) is driving on the road.");
    }
}

public class Motorcycle : Vehicle
{
    public Motorcycle(string name) : base(name) { }
    public override void Drive()
    {
        Console.WriteLine($"{Name} (Motorcycle) is speeding along the highway.");
    }
}

public class Truck : Vehicle
{
    public Truck(string name) : base(name) { }
    public override void Drive()
    {
        Console.WriteLine($"{Name} (Truck) is carrying goods.");
    }
}

class Program
{
    static void Main()
    {
        // array of Vehicle
        Vehicle[] vehicles = new Vehicle[]
        {
            new Car("Suzuki Swift"),
            new Motorcycle("Yamaha Gladiator"),
            new Truck("Asok Leyland")
        };

        // iterating through each vehicle
        foreach (Vehicle v in vehicles)
        {
            v.Drive(); // Polymorphic behavior
        }
    }
}

