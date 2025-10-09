using System;
using System.Collections.Generic;
public enum AnimalType
{
    Domestic,
    Wild
}

public enum FoodType
{
    Herbivore,
    Carnivore,
    Omnivore
}

public enum Gender
{
    Male,
    Female
}


public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public AnimalType Type { get; set; }
    public FoodType Food { get; set; }
    public Gender Gender { get;set; }
    public Animal(int id,string name, AnimalType type, FoodType food,Gender gender)
    {
        Id = id; 
        Name = name;
        Type = type;
        Food = food;
        Gender = gender;
    }
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}, Type: {Type}, Food: {Food}, Gender:{Gender}");
    }
    public virtual void MakeSound()
    {
        Console.WriteLine("Some generic animal sound.");
    }
}

// Lion with its unique property ManeLength
public class Lion : Animal
{
    public int ManeLength { get; set; }

    public Lion(int id, string name, AnimalType type, FoodType food, Gender gender, int maneLength = 0)
        : base(id, name, type, food,gender)
    {
        // If female, maneLength is always 0 no matter what is passed
        ManeLength = (gender == Gender.Female) ? 0 : maneLength;
    }

    public override void MakeSound()
    {
        Console.WriteLine("Roar!");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Mane Length: {ManeLength}");
    }
}

// Tiger with its unique property StripeCount
public class Tiger : Animal
{
    public int StripeCount { get; set; }

    public Tiger(int id, string name, AnimalType type, FoodType food, Gender gender, int stripeCount = 0)
        : base(id, name, type, food,gender)
    {
        StripeCount = stripeCount;
    }

    public override void MakeSound()
    {
        Console.WriteLine("Roar!");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Stripe Count: {StripeCount}");
    }
}

// Deer with its unique property NoOfAntler/ Horns
public class Deer : Animal
{
    public int NoOfAntler { get; set; }

    public Deer(int id, string name, AnimalType type, FoodType food, Gender gender, int noOfAntler = 0)
        : base(id, name, type, food,gender)
    {
        NoOfAntler = noOfAntler;
    }

    public override void MakeSound()
    {
        Console.WriteLine("Bleat!");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Number of Antlers/Horns: {NoOfAntler}");
    }
}

// Snake with its unique property PoisonType
public class Snake : Animal
{
    public bool PoisonType { get; set; }

    public Snake(int id, string name, AnimalType type, FoodType food, Gender gender, bool poisonType )
        : base(id, name, type, food, gender)
    { 
        PoisonType = poisonType;
    }

    public override void MakeSound()
    {
        Console.WriteLine("Hiss!");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        if (PoisonType)
        {
            Console.WriteLine($"Poisonous");
        }
        else
        {
            Console.WriteLine($"Non-Poisonous");
        }
    }
}


// Bird with its unique property CanFly
public class Bird : Animal
{
    public bool CanFly { get; set; }

    public Bird(int id, string name, AnimalType type, FoodType food, Gender gender, bool canFly)
        : base(id, name, type, food, gender)
    {
        CanFly = canFly;
    }


    public override void MakeSound()
    {
        Console.WriteLine("Chirp!");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        if (CanFly)
        {
            Console.WriteLine("Can Fly");
        }
        else
        {
            Console.WriteLine("Cannot Fly");
        }
    }
}

public class Monkey : Animal
{
    public Monkey(int id, string name, AnimalType type, FoodType food, Gender gender)
        : base(id, name, type, food, gender)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Whoop!");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
    }
}

public class Rabbit : Animal
{
    public Rabbit(int id, string name, AnimalType type, FoodType food, Gender gender)
        : base(id, name, type, food, gender)
    {

    }

    public override void MakeSound()
    {
        Console.WriteLine("Grunt");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
    }
}

public class Bear : Animal
{
    public Bear(int id, string name, AnimalType type, FoodType food, Gender gender)
        : base(id, name, type, food,gender)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Growl!");
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
    }
}


class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>
        {
            new Lion(1, "Savannah Lion", AnimalType.Wild, FoodType.Carnivore, Gender.Male, 30),
            new Tiger(2, "Bengal Tiger", AnimalType.Wild, FoodType.Carnivore, Gender.Male, 40),
            new Deer(3, "Barasingha Deer", AnimalType.Wild, FoodType.Herbivore, Gender.Female, 0),
            new Snake(4, "King Cobra", AnimalType.Wild, FoodType.Carnivore, Gender.Female, true),
            new Bird(5, "Eagle", AnimalType.Wild, FoodType.Carnivore, Gender.Male, true),
            new Monkey(6, "Assamese Monkey", AnimalType.Wild, FoodType.Omnivore, Gender.Male),
            new Bear(7, "Grizzly Bear", AnimalType.Wild, FoodType.Omnivore, Gender.Male),
            new Rabbit(8, "Cottontail Rabbit", AnimalType.Domestic, FoodType.Herbivore,Gender.Male)
        };

        foreach (var animal in animals)
        {
            animal.DisplayInfo();
            animal.MakeSound();
            Console.WriteLine();
        }
    }
}