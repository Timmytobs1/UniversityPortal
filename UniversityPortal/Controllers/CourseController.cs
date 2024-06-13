using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityPortal.Data;
using UniversityPortal.Dtos.Course;
using UniversityPortal.Dtos.CourseRegistration;
using UniversityPortal.Interface;
using UniversityPortal.Mappers;
using UniversityPortal.Models;

namespace UniversityPortal.Controllers
{

    [Route("api/course")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICourseRepository _courseRepo;
        public CourseController(ApplicationDbContext context, ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseRepo.GetAllAsync();

            return Ok(courses);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var course = await _courseRepo.GetByIdAsync(id);

            if (course == null)
            {
                return NotFound();

            }

            return Ok(course.ToCourseDto());
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddCourseDto courseDto)
        {
            var courseModel = courseDto.ToCourseFromAddDTO();
            await _courseRepo.CreateAsync(courseModel);
            return CreatedAtAction(nameof(GetById), new { id = courseModel.CourseId }, courseModel.ToCourseDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCourseDto updateDto)
        {
            var courseModel = await _courseRepo.UpdateAsync(id, updateDto);


            if (courseModel == null)
            {
                return NotFound();
            }

            return Ok(courseModel.ToCourseDto());
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var courseModel = await _courseRepo.DeleteAsync(id);

            if (courseModel == null)
            {
                return NotFound();
            }
            return NoContent();

        }
        [HttpPost]
        [Route("courseregistration")]
        public async Task<IActionResult> CreateAsync( [FromBody]CourseRegistrationDto course)
        {
            var syu = await _context.CoursesRegistrations.AnyAsync(x => x.CourseId == course.CourseId && x.StudentId == course.StudentId);
            if (syu)
            {
                return BadRequest("Duplicate Entry");
            }
            else
            {
                await _context.CoursesRegistrations.AddAsync(course.ToCourseFromAddDTO());
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

    }
}
