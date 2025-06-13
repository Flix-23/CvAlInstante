using CvAlInstante.Entities;
using Microsoft.EntityFrameworkCore;

namespace CvAlInstante.Data
{
    public class CvDbContext : DbContext
    {
        public CvDbContext(DbContextOptions<CvDbContext> options) : base(options) { }

        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
