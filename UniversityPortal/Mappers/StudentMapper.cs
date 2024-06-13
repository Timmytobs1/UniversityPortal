using UniversityPortal.Dtos.Student;
using UniversityPortal.Models;

namespace UniversityPortal.Mappers
{
    public static class StudentMapper
    {
     public static StudentDto ToStudentDto(this Student studentModel)
        {
            return new StudentDto
            {
                StudentId = studentModel.StudentId,
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName,
                Email = studentModel.Email,
                Phone = studentModel.Phone,
                Age = studentModel.Age,
                DateOfBirth = studentModel.DateOfBirth,
                MatricNo = studentModel.MatricNo,
                Courses = studentModel.RegisteredCourse.Select(x => x.Course).Select(y => y.CourseTitle).ToList(),
            };
        }

        public static Student ToStudentFromAddDTO(this AddStudentDto studentDto)
        {
            return new Student
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
                Phone = studentDto.Phone,
                Age = studentDto.Age,
                DateOfBirth = studentDto.DateOfBirth
            };
        }
    }
}
