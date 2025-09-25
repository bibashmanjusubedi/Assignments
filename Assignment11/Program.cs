class Car
{
    public string make { get; set; }
    public string model { get; set; }
    int year { get; set; }
    string color { get; set; }

    public double position { get; set; }
    public int timeElapsed {get;set;}

    public Car(string make="McLaren",string model="F1",int year=2002,string color="black") 
    {
        this.make = make;
        this.model = model;
        this.year = year;
        this.color = color;
    }
    public void Start()
    {
        position = 0;
        timeElapsed = 0;
        Console.WriteLine("Car has started");
        System.Threading.Thread.Sleep(1000); // Simulate time delay
        for (int time = 0; time < 600; time++)
        {
            if (time==500)
            {
                this.Accelerate(); // Accelerate at 500 seconds
            }
            if (time==590)
            {
                this.Accelerate(); // Accelerate again at 590 seconds
            }
            position += 1;
            timeElapsed += 1;
        }
               
        
    }

    public void Stop()
    {
        Console.WriteLine($"Car has stopped. Distance covered: {position} meters in {timeElapsed} seconds.");
    }

    public void Accelerate()
    {
        Console.WriteLine("Car is accelerating");
        position +=1;

    }

    public void GetInfo()
    {
        Console.WriteLine($"Car Make: {make}, Model: {model}, Year: {year}, Color: {color}");
    }
}

class Book
{
    public int id { get; set; }
    public string title { get; set; }
    public string author { get; set; }
    public int published_year { get; set; }

    public DateOnly borrowed_date { get; set; }
    public DateOnly date_to_return { get; set; }
    public DateOnly returned_date { get; set; }
    public Book(int id, string title, int year,string author)
    {
        this.id = id;
        this.title = title;
        this.published_year = year;
        this.author = author;
    }

    public void GetInfo()
    {
        Console.WriteLine($"Book ID: {id}, Title: {title}, Author: {author}, Published Year: {published_year}");
    }

    public void Borrow()
    {
        borrowed_date = new DateOnly(2025,9,20);
        Console.WriteLine($"Book '{title}' has been borrowed on {borrowed_date}");
        date_to_return = borrowed_date.AddDays(15);
        Console.WriteLine($"The date to return is {date_to_return}");
    }

    public void Return()
    {
        returned_date = new DateOnly(2025,9,29);
        if (returned_date < date_to_return)
        {
            Console.WriteLine($"Book '{title}' has been returned on {returned_date}. Thank you! for returning the book in time");
        }
        else
        {
            Console.WriteLine($"Book '{title}' has been returned on {returned_date} but the date to return is {date_to_return}.Sorry! you will be fined.");
        }
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("Car Details:");
        Car myCar = new Car();
        myCar.GetInfo();
        myCar.Start();
        myCar.Stop();

        Console.WriteLine("\nBook Details:");
        Book myBook = new Book(1, "Harry Potter And The Chamber of Secrets", 1990,"JK Rowling");
        myBook.GetInfo();
        myBook.Borrow();
        myBook.Return();
    }
}
