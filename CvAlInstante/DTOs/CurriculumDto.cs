using CvAlInstante.DTOs;

namespace CvAlInstante.DTOS
{
    public class CurriculumDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Profile { get; set; }
        public List<EducationDto> Educations { get; set; }
        public List<ExperienceDto> Experiences { get; set; }
        public List<SkillDto> Skills { get; set; }
        public int CurriculumId { get; set; }

    }

}
