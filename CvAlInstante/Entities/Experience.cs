using System.ComponentModel.DataAnnotations.Schema;

namespace CvAlInstante.Entities
{
    [Table("Experiences")]
    public class Experience
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }
    }
}
