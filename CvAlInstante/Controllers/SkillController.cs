using CvAlInstante.Data;
using CvAlInstante.DTOs;
using CvAlInstante.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CvAlInstante.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly CvDbContext _context;
        public SkillController(CvDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var skills = await _context.Skills.Include(s => s.Curriculum).ToListAsync();
            var result = skills.Select(s => new SkillDto
            {
                Name = s.Name,
                Level = s.Level
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill([FromBody] SkillDto dto)
        {
            var skill = new Skill
            {
                Name = dto.Name,
                Level = dto.Level,
                CurriculumId = dto.CurriculumId
            };

            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return Ok(skill);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SkillDto dto)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null) return NotFound();

            skill.Name = dto.Name;
            skill.Level = dto.Level;
            await _context.SaveChangesAsync();
            return Ok(skill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null) return NotFound();

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
