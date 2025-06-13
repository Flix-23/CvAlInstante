using CvAlInstante.Data;
using CvAlInstante.DTOs;
using CvAlInstante.DTOS;
using CvAlInstante.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CvAlInstante.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurriculumController : ControllerBase
    {
        private readonly CvDbContext _context;
        public CurriculumController(CvDbContext context) => _context = context;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CurriculumDto dto)
        {
            var curriculum = new Curriculum
            {
                FullName = dto.FullName,
                ProfesionalProfile = dto.Profile,
                Educations = [.. dto.Educations.Select(e => new Education
                {
                    Institution = e.Institution,
                    Degree = e.Degree,
                    StartYear = e.StartYear,
                    EndYear = e.EndYear
                })],
                Experiences = [.. dto.Experiences.Select(e => new Experience
                {
                    Company = e.Company,
                    Role = e.Role,
                    Description = e.Description,
                    StartYear = e.StartYear,
                    EndYear = e.EndYear
                })],
                Skills = [.. dto.Skills.Select(s => new Skill
                {
                    Name = s.Name,
                    Level = s.Level
                })]
            };

            _context.Curriculums.Add(curriculum);
            await _context.SaveChangesAsync();
            return Ok(curriculum);
        }

        [HttpGet("pdf/{id}")]
        public async Task<IActionResult> DescargarPdf(int id)
        {
            var curriculum = await _context.Curriculums
                .Include(c => c.Educations)
                .Include(c => c.Experiences)
                .Include(c => c.Skills)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (curriculum == null)
            {
                return NotFound();
            }

            var pdfBytes = CurriculumPdfGenerator.GenerarPDF(curriculum);
            return File(pdfBytes, "application/pdf", $"curriculum_{id}.pdf");
        }

    }
}
