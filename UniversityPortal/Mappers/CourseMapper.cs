using UniversityPortal.Dtos.Course;
using UniversityPortal.Dtos.Student;
using UniversityPortal.Models;

namespace UniversityPortal.Mappers
{
    public static  class CourseMapper
    {
        public static CourseDto ToCourseDto(this Course courseModel)
        {
            return new CourseDto
            {
                CourseId = courseModel.CourseId,
                CourseTitle = courseModel.CourseTitle,
                CourseUnit = courseModel.CourseUnit,
                CourseCode = courseModel.CourseCode,
               

            };
        }

        public static Course ToCourseFromAddDTO(this AddCourseDto courseDto)
        {
            return new Course
            {
                CourseTitle = courseDto.CourseTitle,
                CourseUnit = courseDto.CourseUnit,
                CourseCode = courseDto.CourseCode,
           
               
            };
        }

    }
}
