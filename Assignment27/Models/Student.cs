using System.ComponentModel.DataAnnotations;

namespace Assignment27.Models
{
    public class Student
    {
        public int Id { get; set; }           // Unique identifier for the student

        [Required(ErrorMessage="Name is Required")]
        [StringLength(50,ErrorMessage ="Name cannot exceed 50 characters")]
        public string Name { get; set; }      // Student's full name

        [Required(ErrorMessage="Age is Required")]
        [Range(1, 120, ErrorMessage ="Age must be between 1 and 120")]
        public int Age { get; set; }          // Student's age

        [Required(ErrorMessage="Email is Required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }     // Student's email address
    }
}
