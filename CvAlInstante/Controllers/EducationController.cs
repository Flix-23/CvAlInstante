using CvAlInstante.Data;
using CvAlInstante.DTOs;
using CvAlInstante.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CvAlInstante.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : ControllerBase
    {
        private readonly CvDbContext _context;
        public EducationController(CvDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var educations = await _context.Educations.Include(e => e.Curriculum).ToListAsync();
            var result = educations.Select(e => new EducationDto
            {
                Institution = e.Institution,
                Degree = e.Degree,
                StartYear = e.StartYear,
                EndYear = e.EndYear
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddEducation([FromBody] EducationDto dto)
        {
            var education = new Education
            {
                Institution = dto.Institution,
                Degree = dto.Degree,
                StartYear = dto.StartYear,
                EndYear = dto.EndYear,
                CurriculumId = dto.CurriculumId
            };

            _context.Educations.Add(education);
            await _context.SaveChangesAsync();
            return Ok(education);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EducationDto dto)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null) return NotFound();

            education.Institution = dto.Institution;
            education.Degree = dto.Degree;
            education.StartYear = dto.StartYear;
            education.EndYear = dto.EndYear;

            await _context.SaveChangesAsync();
            return Ok(education);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null) return NotFound();

            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
