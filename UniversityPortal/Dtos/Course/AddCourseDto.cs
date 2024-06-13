using System.ComponentModel.DataAnnotations;

namespace UniversityPortal.Dtos.Course
{
    public class AddCourseDto
    {

        public string CourseTitle { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;
        public string CourseUnit { get; set; } = string.Empty;
    }
}
