using Microsoft.EntityFrameworkCore;
using UniversityPortal.Data;
using UniversityPortal.Dtos.Course;
using UniversityPortal.Dtos.Student;
using UniversityPortal.Interface;
using UniversityPortal.Models;

namespace UniversityPortal.Repository
{
    public class CourseRepository : ICourseRepository
    {

        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Course> CreateAsync(Course courseModel)
        {
            await _context.Courses.AddAsync(courseModel);
            await _context.SaveChangesAsync();
            return courseModel;
        }

     

        public async Task<Course?> DeleteAsync(Guid id)
        {
            var courseModel = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
            if (courseModel == null)
            {
                return null;
            }

            _context.Courses.Remove(courseModel);
            await _context.SaveChangesAsync();
            return courseModel;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(Guid id)
        {
            return await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
        }



        public async Task<Course?> UpdateAsync(Guid id, UpdateCourseDto courseDto)
        {
            var existingCourse = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);

            if (existingCourse == null)
            {
                return null;
            }

            existingCourse.CourseTitle = courseDto.CourseTitle;
            existingCourse.CourseUnit = courseDto.CourseUnit;
            existingCourse.CourseCode = courseDto.CourseCode;

          

            await _context.SaveChangesAsync();
            return existingCourse;

        }
    }
}
