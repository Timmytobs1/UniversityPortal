using UniversityPortal.Dtos.Course;
using UniversityPortal.Dtos.Student;
using UniversityPortal.Models;

namespace UniversityPortal.Interface
{
    public interface ICourseRepository
    {

        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(Guid id); //FirstOrDefault CAN BE NULL
        Task<Course> CreateAsync(Course courseModel);
        Task<Course?> UpdateAsync(Guid id, UpdateCourseDto courseDto);
        Task<Course?> DeleteAsync(Guid id);
    }
}
