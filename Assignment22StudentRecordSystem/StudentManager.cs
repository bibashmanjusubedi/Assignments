using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment22StudentRecordSystem
{
    public class StudentManager
    {
        private readonly string _csvPath;
        private readonly List<Student> _students = new();

        public StudentManager(string csvPath)
        {
            _csvPath = csvPath;
            LoadFromCsv();
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
            SaveToCsv();
        }

        public void ListStudents()
        {
            Console.WriteLine("\n--- Student Records ---");
            if (_students.Count == 0)
            {
                Console.WriteLine("No records found.");
                return;
            }

            foreach (var s in _students)
                Console.WriteLine($"{s.Id}, {s.FullName}, {s.Age}, {s.Grade}");
        }

        private void LoadFromCsv()
        {
            if (!File.Exists(_csvPath)) return;

            _students.Clear();

            // Safely open file for reading with shared read access
            using (var fs = new FileStream(_csvPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new StreamReader(fs))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split(',');
                    if (data.Length == 4)
                    {
                        _students.Add(new Student
                        {
                            Id = int.Parse(data[0]),
                            FullName = data[1],
                            Age = int.Parse(data[2]),
                            Grade = data[3]
                        });
                    }
                }
            }
        }


        private void SaveToCsv()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_csvPath)!);

            // Compose all lines before writing
            var lines = new List<string>();
            foreach (var s in _students)
                lines.Add($"{s.Id},{s.FullName},{s.Age},{s.Grade}");

            // Use FileStream to ensure file handle is released
            using (var fs = new FileStream(_csvPath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var writer = new StreamWriter(fs))
            {
                foreach (var line in lines)
                    writer.WriteLine(line);
            }
        }

    }
}
