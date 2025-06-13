using CvAlInstante.Data;
using CvAlInstante.DTOs;
using CvAlInstante.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CvAlInstante.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperienceController : ControllerBase
    {
        private readonly CvDbContext _context;
        public ExperienceController(CvDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var experiences = await _context.Experiences.Include(e => e.Curriculum).ToListAsync();
            var result = experiences.Select(e => new ExperienceDto
            {
                Company = e.Company,
                Role = e.Role,
                Description = e.Description,
                StartYear = e.StartYear,
                EndYear = e.EndYear
            });

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddExperience([FromBody] ExperienceDto dto)
        {
            var experience = new Experience
            {
                Company = dto.Company,
                Role = dto.Role,
                Description = dto.Description,
                StartYear = dto.StartYear,
                EndYear = dto.EndYear,
                CurriculumId = dto.CurriculumId
            };

            _context.Experiences.Add(experience);
            await _context.SaveChangesAsync();
            return Ok(experience);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ExperienceDto dto)
        {
            var experience = await _context.Experiences.FindAsync(id);
            if (experience == null) return NotFound();

            experience.Company = dto.Company;
            experience.Role = dto.Role;
            experience.Description = dto.Description;
            experience.StartYear = dto.StartYear;
            experience.EndYear = dto.EndYear;

            await _context.SaveChangesAsync();
            return Ok(experience);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            if (experience == null) return NotFound();

            _context.Experiences.Remove(experience);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
