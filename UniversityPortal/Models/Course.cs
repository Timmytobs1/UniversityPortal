using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UniversityPortal.Models
{
    [Index("CourseTitle", IsUnique = true)]
    [Index("CourseCode", IsUnique = true)]
    public class Course
    {
        public Guid CourseId { get; set; }
        [Required]
        [StringLength(50)]
        public string CourseTitle { get; set; } = string.Empty;
        [Required]
        [StringLength(10)]
        public string CourseCode { get; set; } = string.Empty;
        [Required]
        [StringLength(10)]
        public string CourseUnit { get; set; } = string.Empty;
        public List<CourseRegistration> courseRegistrations { get; set; } = new List<CourseRegistration>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;

    }
}
