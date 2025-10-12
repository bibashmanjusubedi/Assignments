using System.Diagnostics.Contracts;

public interface IFlyable
{
    void Fly();
}

public interface ISwimmable
{
    void Swim();
}

public interface IDriveable
{
    void Drive();
}

// Example class that implements IFlyable and ISwimmable
public class Duck : IFlyable, ISwimmable
{
    public void Fly()
    {
        Console.WriteLine("The duck is flying.");
    }
    public void Swim()
    {
        Console.WriteLine("The duck is swimming.");
    }
}

public class Robot: IFlyable, IDriveable, ISwimmable
{
    public void Fly()
    {
        Console.WriteLine("The robo-drone is flying.");
    }
    public void Drive()
    {
        Console.WriteLine("The robo-car is driving.");
    }
    public void Swim()
    {
        Console.WriteLine("The robo-boat is swimming.");
    }
}

// Example class that implements IDriveable
public class Car : IDriveable
{
    public void Drive()
    {
        Console.WriteLine("The car is driving.");
    }
}

// Example class that implements IFlyable
public class Airplane : IFlyable
{
    public void Fly()
    {
        Console.WriteLine("The airplane is flying high.");
    }
}

public interface IMediaPlayer
{
    void Play();
    void Pause();
    void Stop();
}

public class AudioPlayer : IMediaPlayer
{
    public void Play()
    {
        Console.WriteLine("Playing audio...");
    }
    public void Pause()
    {
        Console.WriteLine("Audio paused.");
    }
    public void Stop()
    {
        Console.WriteLine("Audio stopped.");
    }
}

public class VideoPlayer : IMediaPlayer
{
    public void Play()
    {
        Console.WriteLine("Playing video...");
    }
    public void Pause()
    {
        Console.WriteLine("Video paused.");
    }
    public void Stop()
    {
        Console.WriteLine("Video stopped.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Demonstrate IFlyable, ISwimmable, IDriveable
        Duck duck = new Duck();
        duck.Fly();
        duck.Swim();

        Car car = new Car();
        car.Drive();

        Airplane airplane = new Airplane();
        airplane.Fly();

        Robot transformer = new Robot();
        transformer.Fly();
        transformer.Drive();
        transformer.Swim();

        // Demonstrate IMediaPlayer interface
        IMediaPlayer mx = new AudioPlayer();
        mx.Play();
        mx.Pause();
        mx.Stop();

        IMediaPlayer vlc = new VideoPlayer();
        vlc.Play();
        vlc.Pause();
        vlc.Stop();
    }
}

