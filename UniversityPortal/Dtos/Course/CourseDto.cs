using System.ComponentModel.DataAnnotations;

namespace UniversityPortal.Dtos.Course
{
    public class CourseDto
    {
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;
        public string CourseUnit { get; set; } = string.Empty;

    }
}
