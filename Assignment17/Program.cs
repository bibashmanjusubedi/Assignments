using System;
using System.IO;

class FileReader
{
    static void Main()
    {
        Console.Write("Enter the full path of the file to read: ");
        string path = Console.ReadLine();

        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        // Suppose we want to parse each line to an integer (for FormatException demo)
                        int value = int.Parse(line);
                        Console.WriteLine("Parsed integer: " + value);
                    }
                    catch (FormatException fex)
                    {
                        Console.WriteLine("Format error in file data: " + fex.Message);
                    }
                }
            }
        }
        catch (FileNotFoundException fex)
        {
            Console.WriteLine("File not found: " + fex.FileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }
}
