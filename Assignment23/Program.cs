using System;
using Microsoft.Data.Sqlite;

namespace SchoolDatabaseApp
{
    class Program
    {

        static void Main()
        {
            // Step 1: Create tables
            CreateTables();

            // Step 2: Insert sample data
            InsertSampleData(
                 "Hasan Gosain",             // Student Name
                 "hasan@school.org",         // Student Email
                 "9812345678",               // Student Phone
                 "2025-10-28",               // Enrollment Date
                 "CS50",              // Course Title
                 "Intro To Computer Science" // Course Description
            );


            // Step 3: Query student info
            Console.WriteLine("Student information roster:");
            QueryStudents();

            // Step 4: Update a student's email
            Console.WriteLine("\nUpdating email for student ID 1...");
            UpdateStudentEmail(1, "hasan@school.edu.np");
            QueryStudents();

            // Step 5: Delete a student
            Console.WriteLine("\nDeleting student with ID 1...");
            DeleteStudent(1);
            QueryStudents();
        }

        public static void CreateTables()
        {
            using var connection = new SqliteConnection("Data Source=school.db");
            connection.Open();
            var sqlStudents = @"
                CREATE TABLE IF NOT EXISTS Students (
                    student_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL,
                    email TEXT,
                    phone_number TEXT,
                    enrollment_date TEXT
                );";
            var sqlCourses = @"
                CREATE TABLE IF NOT EXISTS Courses (
                    course_id INTEGER PRIMARY KEY AUTOINCREMENT,
                    title TEXT NOT NULL,
                    description TEXT
                );";
            using var cmd1 = new SqliteCommand(sqlStudents, connection);
            cmd1.ExecuteNonQuery();
            using var cmd2 = new SqliteCommand(sqlCourses, connection);
            cmd2.ExecuteNonQuery();
        }

        public static void InsertSampleData(string studentName, string studentEmail, string studentPhone, string enrollmentDate,
                                            string courseTitle, string courseDesc)
        {
            using var connection = new SqliteConnection("Data Source=school.db");
            connection.Open();
            var insertStudent = @"
                INSERT INTO Students (name, email, phone_number, enrollment_date)
                VALUES (@name, @email, @phone, @date);";
            using var cmd1 = new SqliteCommand(insertStudent, connection);
            cmd1.Parameters.AddWithValue("@name", studentName);
            cmd1.Parameters.AddWithValue("@email", studentEmail);
            cmd1.Parameters.AddWithValue("@phone", studentPhone);
            cmd1.Parameters.AddWithValue("@date", enrollmentDate);
            cmd1.ExecuteNonQuery();

            var insertCourse = @"
                INSERT INTO Courses (title, description)
                VALUES (@title, @desc);";
            using var cmd2 = new SqliteCommand(insertCourse, connection);
            cmd2.Parameters.AddWithValue("@title", courseTitle);
            cmd2.Parameters.AddWithValue("@desc", courseDesc);
            cmd2.ExecuteNonQuery();
        }



        public static void QueryStudents()
        {
            using var connection = new SqliteConnection("Data Source=school.db");
            connection.Open();
            var selectStudents = "SELECT * FROM Students;";
            using var cmd = new SqliteCommand(selectStudents, connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["student_id"]}, Name: {reader["name"]}, Email: {reader["email"]}");
            }
        }

        public static void UpdateStudentEmail(int studentId, string newEmail)
        {
            using var connection = new SqliteConnection("Data Source=school.db");
            connection.Open();
            var updateStudent = @"
                UPDATE Students
                SET email = @newEmail
                WHERE student_id = @id;";
            using var cmd = new SqliteCommand(updateStudent, connection);
            cmd.Parameters.AddWithValue("@newEmail", newEmail);
            cmd.Parameters.AddWithValue("@id", studentId);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteStudent(int studentId)
        {
            using var connection = new SqliteConnection("Data Source=school.db");
            connection.Open();
            var deleteStudent = "DELETE FROM Students WHERE student_id = @id;";
            using var cmd = new SqliteCommand(deleteStudent, connection);
            cmd.Parameters.AddWithValue("@id", studentId);
            cmd.ExecuteNonQuery();
        }


    }
}
