using Microsoft.EntityFrameworkCore;
using UniversityPortal.Models;

namespace UniversityPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseRegistration> CoursesRegistrations { get; set; }

    }
}
