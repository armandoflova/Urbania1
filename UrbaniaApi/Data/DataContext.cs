using Microsoft.EntityFrameworkCore;
using UrbaniaApi.Models;

namespace UrbaniaApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Foto> Foto { get; set; }
    }
}