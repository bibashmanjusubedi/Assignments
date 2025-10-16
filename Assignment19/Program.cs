public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }
    public string Major { get; set; }
}

public class Program
{
    static void Main()
    {
        var students = new List<Student>
        {
            new Student { Name = "Bibash",Age = 26, Grade = "B",Major = "Computer Science"},
            new Student { Name= "Hasan", Age = 24, Grade = "A", Major = "Mathematics"},
            new Student { Name= "Nishil", Age = 22, Grade = "A", Major = "Physics"},
            new Student { Name= "Ramesh", Age = 23, Grade = "C", Major = "Economics"},
        };
        
        Console.WriteLine("All Students:");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name}, Age: {student.Age}, Grade: {student.Grade}, Major: {student.Major}");
        }
        Console.WriteLine();

        var topperStudents = students.Where(s => s.Grade == "A").ToList();
        Console.WriteLine("Topper Students:");
        foreach (var topper in topperStudents)
        {
            Console.WriteLine($"{topper.Name}, Age: {topper.Age}, Grade: {topper.Grade}, Major: {topper.Major}");
        }

        var sortedByAge = students.OrderBy(s => s.Age).ToList();
        Console.WriteLine("\nStudents Sorted by Age:");
        foreach (var student in sortedByAge)
        {
            Console.WriteLine($"{student.Name}, Age: {student.Age}, Grade: {student.Grade}, Major: {student.Major}");
        }

        var groupedByMajor = students.GroupBy(s => s.Major);

        Console.WriteLine("\nStudents Grouped by Major:");
        foreach (var group in groupedByMajor)
        {
            Console.WriteLine($"Major: {group.Key}");
            foreach (var student in group)
            {
                Console.WriteLine($"  {student.Name}  Age:{student.Age} Grade:({student.Grade})");
            }
        }

        var gradeValues = students.Select(s =>
            s.Grade == "A" ? 4 :
            s.Grade == "B" ? 3 :
            s.Grade == "C" ? 2 : 0
        );

        double avgGrade = gradeValues.Average();
        Console.WriteLine($"\nAverage Grade (Numeric): {avgGrade:F2}");

    }
}