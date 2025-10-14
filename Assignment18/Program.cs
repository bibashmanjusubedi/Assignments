using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Contact
{
    public string Name { get; set; }
    public string Phone { get; set; }
}

public class ContactManager
{
    private List<Contact> contacts = new List<Contact>();
    public void AddContact(string name, string phone)
    {
        contacts.Add(new Contact { Name = name, Phone = phone });
    }

    public bool RemoveContact(string name)
    {
        var contact = contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (contact != null)
        {
            contacts.Remove(contact);
            return true;
        }
        return false;
    }

    public List<Contact> SearchByName(string name)
    {
        return contacts
            .Where(c => c.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();
    }

    public void ListContacts()
    {
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.Name} - {contact.Phone}");
        }
    }

}

class WordFrequencyCounter
{
    public static Dictionary<string, int> CountFrequencies(string text)
    {
        var freq = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        var words = text.Split(new[] { ' ', ',', '.', '?', '!', ';', ':', '-', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            if (freq.ContainsKey(word))
                freq[word]++;
            else
                freq[word] = 1;
        }
        return freq;
    }
}


public class TaskQueue
{
    private Queue<string> queue = new Queue<string>();

    // Add a task to the queue
    public void EnqueueTask(string task)
    {
        queue.Enqueue(task);
        Console.WriteLine($"Enqueued: {task}");
    }

    // Remove and return the next task
    public string DequeueTask()
    {
        if (queue.Count > 0)
        {
            string task = queue.Dequeue();
            Console.WriteLine($"Dequeued: {task}");
            return task;
        }
        else
        {
            Console.WriteLine("Queue is empty.");
            return null;
        }
    }

    // Peek at the next task
    public string PeekTask()
    {
        if (queue.Count > 0)
        {
            string task = queue.Peek();
            Console.WriteLine($"Next task: {task}");
            return task;
        }
        else
        {
            Console.WriteLine("Queue is empty.");
            return null;
        }
    }

    // Show queue size
    public int Count => queue.Count;
}

class Program
{
    static void Main()
    {
        // Implement Contact Manager
        var cm = new ContactManager();
        cm.AddContact("Hasan Gosain", "555-0123");
        cm.AddContact("Nishil Maharjan", "555-0456");
        cm.ListContacts();
        var found = cm.SearchByName("Hasan"); // returns list of matching contacts
        cm.RemoveContact("Nishil");

        Console.WriteLine(" ");
        // Implement Word Frequency Counter
        string input = "This is a sample.Sample is a sample";
        var frequencies = WordFrequencyCounter.CountFrequencies(input);
        foreach (var pair in frequencies)
            Console.WriteLine($"{pair.Key}: {pair.Value}");

        Console.WriteLine(" ");
        // Implement Task Queue
        TaskQueue tq = new TaskQueue();
        tq.EnqueueTask("Task 1:Boot Computer");
        tq.EnqueueTask("Task 2: Open Microsoft Teams");
        tq.EnqueueTask("Task 3: Attend Class");
        tq.PeekTask();
        tq.DequeueTask();
        tq.DequeueTask();
        tq.PeekTask();
        tq.DequeueTask();
        tq.PeekTask();
    }

}