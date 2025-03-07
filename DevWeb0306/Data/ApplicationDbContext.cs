using DevWeb0306.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevWeb0306.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Curso> Curso { get; set; }
        public DbSet<Eixo> Eixo { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Professor> Professor { get; set; }
    }
}
