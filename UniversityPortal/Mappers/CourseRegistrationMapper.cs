using UniversityPortal.Dtos.Course;
using UniversityPortal.Dtos.CourseRegistration;
using UniversityPortal.Models;

namespace UniversityPortal.Mappers
{
    public static class CourseRegistrationMapper
    {

        public static CourseRegistrationDto ToDto(this CourseRegistration courseRegistrationModel)
        {
            return new CourseRegistrationDto
            {
                CourseId = courseRegistrationModel.CourseId,
                StudentId = courseRegistrationModel.StudentId,
            };
        }

        public static CourseRegistration ToCourseFromAddDTO(this CourseRegistrationDto courseRegistrationDto)
        {
            return new CourseRegistration
            {
                CourseId = courseRegistrationDto.CourseId,
                StudentId = courseRegistrationDto.StudentId,
                
            };
        }
    }
}
