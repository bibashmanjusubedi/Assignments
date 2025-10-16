using System;
using System.Collections.Generic;

// Interface for member operations
public interface IMember
{
    void BorrowBook(Book book, Library library);
    void ReturnBook(Book book, Library library);
    string GetMemberInfo();
}

// Base Book class
public class Book
{
    public int Id { get; }
    public string Title { get; }
    public string Author { get; }
    public bool IsAvailable { get; set; }

    public Book(int id, string title, string author)
    {
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Book title or author cannot be empty");
        Id = id;
        Title = title;
        Author = author;
        IsAvailable = true;
    }
}

// Base Member class & Polymorphism
public abstract class Member : IMember
{
    public int MemberId { get; }
    public string Name { get; }
    protected List<Book> borrowedBooks = new List<Book>();

    public Member(int memberId, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Member name cannot be empty");
        MemberId = memberId;
        Name = name;
    }
    public abstract string GetMemberInfo();

    public virtual void BorrowBook(Book book, Library library)
    {
        if (!book.IsAvailable)
            throw new InvalidOperationException("Book is not available");
        book.IsAvailable = false;
        borrowedBooks.Add(book);
        library.RecordTransaction(new Transaction(this, book, TransactionType.Borrow));
    }
    public virtual void ReturnBook(Book book, Library library)
    {
        if (!borrowedBooks.Contains(book))
            throw new InvalidOperationException("This member didn’t borrow this book");
        book.IsAvailable = true;
        borrowedBooks.Remove(book);
        library.RecordTransaction(new Transaction(this, book, TransactionType.Return));
    }
}

// Derived member types (demonstrates polymorphism)
public class StudentMember : Member
{
    public StudentMember(int memberId, string name) : base(memberId, name) { }
    public override string GetMemberInfo() => $"Student: {Name} (ID: {MemberId})";
}

public class FacultyMember : Member
{
    public FacultyMember(int memberId, string name) : base(memberId, name) { }
    public override string GetMemberInfo() => $"Faculty: {Name} (ID: {MemberId})";
}

// Transaction class
public enum TransactionType { Borrow, Return }

public class Transaction
{
    public Member Member { get; }
    public Book Book { get; }
    public TransactionType Type { get; }
    public DateTime Date { get; }

    public Transaction(Member member, Book book, TransactionType type)
    {
        Member = member;
        Book = book;
        Type = type;
        Date = DateTime.Now;
    }
}

// Library class using collection for books and members
public class Library
{
    private List<Book> books = new List<Book>();
    private List<Member> members = new List<Member>();
    private List<Transaction> transactions = new List<Transaction>();

    public void AddBook(Book book)
    {
        if (books.Exists(b => b.Id == book.Id))
            throw new InvalidOperationException("Duplicate book ID");
        books.Add(book);
    }

    public void RemoveBook(int bookId)
    {
        var book = books.Find(b => b.Id == bookId);
        if (book == null)
            throw new KeyNotFoundException("Book not found");
        books.Remove(book);
    }

    public void RegisterMember(Member member)
    {
        if (members.Exists(m => m.MemberId == member.MemberId))
            throw new InvalidOperationException("Duplicate member ID");
        members.Add(member);
    }

    public Member FindMember(int memberId) => members.Find(m => m.MemberId == memberId);

    public Book FindBook(int bookId) => books.Find(b => b.Id == bookId);

    public void RecordTransaction(Transaction transaction)
    {
        transactions.Add(transaction);
    }

    public IEnumerable<Book> ListAvailableBooks() => books.FindAll(b => b.IsAvailable);

    public IEnumerable<Transaction> GetAllTransactions() => transactions;
}

// Example usage
class Program
{
    static void Main()
    {
        var library = new Library();

        // Add books
        library.AddBook(new Book(1, "Harry Potter and The Philophers Stone", "JK Rowling"));
        library.AddBook(new Book(2, "A Song of Fire and Ice", "George RR Martin"));

        // Register members
        var student = new StudentMember(101, "Bibash");
        var faculty = new FacultyMember(201, "Hasan");

        library.RegisterMember(student);
        library.RegisterMember(faculty);

        // Borrow and return books
        student.BorrowBook(library.FindBook(1), library);
        faculty.BorrowBook(library.FindBook(2), library);
        student.ReturnBook(library.FindBook(1), library);

        // Display transactions
        foreach (var t in library.GetAllTransactions())
            Console.WriteLine($"{t.Type}: {t.Book.Title} by {t.Member.Name} on {t.Date}");
    }
}
