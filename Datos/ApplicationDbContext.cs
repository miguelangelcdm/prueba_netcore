using Microsoft.EntityFrameworkCore;
using webappBD.Models;

namespace webappBD.Datos
{
    public class ApplicationDbContext:DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Usuario> Usuario{get;set;}
    }

}