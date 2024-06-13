using Microsoft.EntityFrameworkCore;
using System.Data;
using UniversityPortal.Data;
using UniversityPortal.Dtos.Student;
using UniversityPortal.Interface;
using UniversityPortal.Mappers;
using UniversityPortal.Models;

namespace UniversityPortal.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateAsync(Student studentModel)
        {
            await _context.Students.AddAsync(studentModel);
            await _context.SaveChangesAsync();
            var student = _context.Students.FirstOrDefault(x => x.Email == studentModel.Email);
            student.MatricNo = GenerateMatricNo();
            Console.WriteLine(student.MatricNo);
            await _context.SaveChangesAsync();
            return studentModel;
        }

        public async Task<Student?> DeleteAsync(Guid id)
        {
            var studentModel = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (studentModel == null)
            {
                return null;
            }

            _context.Students.Remove(studentModel);
            await _context.SaveChangesAsync();
            return studentModel;
        }

        public int GenerateMatricNo()
        {
            // Assuming matriculation number format: 20240001, where 2024 is the current year
            int currentYear = DateTime.Now.Year;
            int lastTwoDigitsOfYear = currentYear % 100; // Extract last two digits
            string yearPrefix = lastTwoDigitsOfYear.ToString("D2"); // Ensure two digits

            // You need to implement the logic to get the count of students registered in the current year.
            Random rand = new Random();
            int studentCount = rand.Next(19000); // Get count of students registered in the current year and increment by 1
            string studentCountSuffix = studentCount.ToString("D6"); // Ensure four digits

            int matricNo = int.Parse(yearPrefix + studentCountSuffix);
            return matricNo;
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            return await _context.Students.Include(x => x.RegisteredCourse).ThenInclude(y => y.Course).Select(z => z.ToStudentDto()).ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
        }

       

        public async Task<Student?> UpdateAsync(Guid id, UpdateStudentDto studentDto)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(x => x.StudentId == id);

            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.FirstName = studentDto.FirstName;
            existingStudent.LastName = studentDto.LastName;
            existingStudent.Email = studentDto.Email;
            existingStudent.Phone = studentDto.Phone;
            existingStudent.Age = studentDto.Age;
            existingStudent.DateOfBirth = studentDto.DateOfBirth;

            await _context.SaveChangesAsync();
            return existingStudent;

        }



    }
}
