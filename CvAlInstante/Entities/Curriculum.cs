using System.ComponentModel.DataAnnotations.Schema;

namespace CvAlInstante.Entities
{
    [Table("Curriculums")]
    public class Curriculum
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        public string FullName { get; set; }
        public string ProfesionalProfile { get; set; }
        public List<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Skill> Skills { get; set; }
    }

}
