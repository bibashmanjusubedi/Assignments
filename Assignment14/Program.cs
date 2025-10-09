using System;

// Base class Animal
public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void MakeSound()
    {
        Console.WriteLine("The animal makes a sound.");
    }
}

// Derived class Dog
public class Dog : Animal
{
    public Dog(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine("The dog barks.");
    }
}

// Derived class Cat
public class Cat : Animal
{
    public Cat(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine("The cat meows.");
    }
}

// Derived class Bird
public class Bird : Animal
{
    public Bird(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine("The bird chirps.");
    }
}

// Base class Shape
public class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine("Performing base class drawing tasks.");
    }
}

// Derived class Rectangle
public class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a rectangle.");
    }
}

// Derived class Circle
public class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle.");
    }
}

class Program
{
    static void Main()
    {
        Dog dog = new Dog("Buddy", 3);
        Cat cat = new Cat("Whiskers", 2);
        Bird bird = new Bird("Tweety", 1);

        dog.MakeSound(); // The dog barks.
        cat.MakeSound(); // The cat meows.
        bird.MakeSound(); // The bird chirps.

        Rectangle rect = new Rectangle();
        Circle circle = new Circle();

        rect.Draw();   // Drawing a rectangle.

        circle.Draw(); // Drawing a circle.


    }
}