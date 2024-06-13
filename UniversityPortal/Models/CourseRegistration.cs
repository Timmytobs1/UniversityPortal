using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityPortal.Models
{
    public class CourseRegistration
    {

        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
