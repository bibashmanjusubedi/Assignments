namespace Assignment24
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public DateTime Enrollment { get; set; }

        // many-to-many for student to course
        public List<Course> Courses { get; } = new List<Course>();

        // one-to-many for student to grades
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }

}
