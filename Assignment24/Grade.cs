
namespace Assignment24
{
    public class Grade
    {
        public int Id { get; set; }
        public string GradeValue { get; set; } = string.Empty;

        // Foreign key: student
        public int StudentId { get; set; }
        // one to many for student to grades ..navigation property for student
        public Student Student { get; set; } = null!;
    }
}
