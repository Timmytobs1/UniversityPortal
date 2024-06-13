using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityPortal.Models
{
    [Index("Email", IsUnique = true)]
    [Index("MatricNo", IsUnique = true)]
    public class Student
    {
        public Guid StudentId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        public int MatricNo { get; set; } // Removed [Required] attribute
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Phone { get; set; }
        public List<CourseRegistration> RegisteredCourse { get; set; } = new List<CourseRegistration>();
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public DateTime RegistredAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;


    }
}
