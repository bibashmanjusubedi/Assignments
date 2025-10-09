using System;

/// <summary>
/// Represents a geometric shape.
/// </summary>
public interface IShape // all interfaces start with I by convention
{
    /// <summary>
    /// Draws the shape on a graphical surface.
    /// </summary>
    void Draw();

    /// <summary>
    /// Calculates the area of the shape.
    /// </summary>
    /// <returns>The computed area as a double.</returns>
    double Area();
}

/// <summary>
/// Represents a rectangle shape.
/// </summary>
public class Rectangle : IShape
{
    /// <summary>
    /// The width of the rectangle.
    /// </summary>
    private double width;

    /// <summary>
    /// The height of the rectangle.
    /// </summary>
    private double height;

    /// <summary>
    /// Initializes a new instance of the <see cref="Rectangle"/> class,
    /// setting its width and height.
    /// </summary>
    /// <param name="width">The rectangle's width.</param>
    /// <param name="height">The rectangle's height.</param>
    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    /// <summary>
    /// Draws the rectangle (implementation example).
    /// </summary>
    public void Draw()
    {
        Console.WriteLine("Drawing Rectangle");
    }

    /// <summary>
    /// Calculates the area of the rectangle.
    /// </summary>
    /// <returns>The area as width multiplied by height.</returns>
    public double Area()
    {
        return width * height;
    }
}

/// <summary>
/// Main program to demonstrate interface usage.
/// </summary>
public class Program
{
    public static void Main()
    {
        // Create a rectangle object with width 5 and height 3
        IShape shape = new Rectangle(5, 3);

        // Draw the shape
        shape.Draw();

        // Calculate and print the area
        double area = shape.Area();
        Console.WriteLine("Area: " + area);
    }
}
