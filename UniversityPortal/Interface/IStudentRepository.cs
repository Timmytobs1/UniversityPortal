using UniversityPortal.Dtos.Student;
using UniversityPortal.Models;

namespace UniversityPortal.Interface
{
    public interface IStudentRepository
    {
        Task<List<StudentDto>> GetAllAsync();
        Task<Student?> GetByIdAsync(Guid id); //FirstOrDefault CAN BE NULL
        Task<Student> CreateAsync(Student studentModel);
        Task<Student?> UpdateAsync(Guid id, UpdateStudentDto studentDto);
        Task<Student?> DeleteAsync(Guid id);
        public int GenerateMatricNo();
    }
}
