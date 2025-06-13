using System.ComponentModel.DataAnnotations.Schema;

namespace CvAlInstante.Entities
{
    [Table("Skills")]
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int CurriculumId { get; set; }

        public Curriculum Curriculum { get; set; }
    }
}
