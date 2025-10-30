
namespace Assignment24
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;


        // many to many for student to course
        public List<Student> Students { get; } = new List<Student>();
    }
}
