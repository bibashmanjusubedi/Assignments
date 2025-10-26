using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace FileProcessorApp
{
    public class TextFileProcessor
    {
        private readonly string _filePath;

        public TextFileProcessor(string filePath)
        {
            _filePath = filePath;
        }

        // Count lines, words, and characters in the text file
        public (int lineCount, int wordCount, int charCount) AnalyzeText()
        {
            int lineCount = 0, wordCount = 0, charCount = 0;
            foreach (var line in File.ReadLines(_filePath))
            {
                lineCount++;
                wordCount += line.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                charCount += line.Length;
            }
            return (lineCount, wordCount, charCount);
        }

        // Create a backup copy of the file
        public string CreateBackup()
        {
            string backupFile = _filePath + ".bak";
            File.Copy(_filePath, backupFile, true);
            return backupFile;
        }

        // Search for specific text in the file (case-insensitive)
        public bool SearchText(string searchTerm)
        {
            foreach (var line in File.ReadLines(_filePath))
            {
                if (line.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }

    // Log File Writer for application logging
    public static class LogFileWriter
    {
        private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.log");

        public static void WriteLog(string message)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
        }

        public static void WriteError(string errorMessage)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {errorMessage}";
            File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
        }
    }

    public class Program
    {
        public static void Main()
        {
            try
            {
                var processor = new TextFileProcessor(@"E:\AmnilTechnologies\Files\example.txt");


                // Analyze the text file for counts
                var (lines, words, chars) = processor.AnalyzeText();

                // Create a backup
                var backupFile = processor.CreateBackup();

                // Search for text
                bool found = processor.SearchText("important");

                // Log the operations
                LogFileWriter.WriteLog($"File analyzed. Lines={lines}, Words={words}, Characters={chars}");

                if (found)
                    LogFileWriter.WriteLog("Search term 'important' found in file.");
                else
                    LogFileWriter.WriteLog("Search term 'important' not found in file.");

                Console.WriteLine("Text file processing complete. Check app.log for details.");
            }
            catch (Exception ex)
            {
                LogFileWriter.WriteError($"An error occurred: {ex.Message}");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
