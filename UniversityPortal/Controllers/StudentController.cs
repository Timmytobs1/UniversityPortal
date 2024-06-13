using Microsoft.AspNetCore.Mvc;
using UniversityPortal.Data;
using UniversityPortal.Dtos.Student;
using UniversityPortal.Interface;
using UniversityPortal.Mappers;

namespace UniversityPortal.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStudentRepository _studentRepo;
        public StudentController(ApplicationDbContext context, IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepo.GetAllAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var student = await _studentRepo.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();

            }

            return Ok(student.ToStudentDto());
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddStudentDto studentDto)
        {
            var studentModel = studentDto.ToStudentFromAddDTO();
            await _studentRepo.CreateAsync(studentModel);
            return CreatedAtAction(nameof(GetById), new { id = studentModel.StudentId }, studentModel.ToStudentDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateStudentDto updateDto)
        {
            var studentModel = await _studentRepo.UpdateAsync(id, updateDto);


            if (studentModel == null)
            {
                return NotFound();
            }

            return Ok(studentModel.ToStudentDto());
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var studentModel = await _studentRepo.DeleteAsync(id);

            if (studentModel == null)
            {
                return NotFound();
            }
            return NoContent();

        }
        [HttpPatch("AddMatric/id")]

        public async Task<IActionResult> AddMatricNo(Guid id)
        {
            var studentModel = await _studentRepo.GetByIdAsync(id);
            studentModel.MatricNo = _studentRepo.GenerateMatricNo();
            await _context.SaveChangesAsync();
            return Ok(studentModel.ToStudentDto());
        }
    }
}
