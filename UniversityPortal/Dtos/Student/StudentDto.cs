
using UniversityPortal.Dtos.CourseRegistration;
using UniversityPortal.Models;

namespace UniversityPortal.Dtos.Student
{
    public class StudentDto
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int MatricNo { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public List<string> Courses { get; set; } = new List<string>();
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

      
    }
}
