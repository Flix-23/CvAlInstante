using System.ComponentModel.DataAnnotations.Schema;

namespace CvAlInstante.Entities
{
    [Table("Educations")]
    public class Education
    {
        public int Id { get; set; }
        public string Institution { get; set; }
        public string Degree { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int CurriculumId { get; set; }

        public Curriculum Curriculum { get; set; }
    }
}
