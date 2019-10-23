using Microsoft.EntityFrameworkCore;
using UrbaniaApi.Models;

namespace UrbaniaApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Usuario> Usuarios { get; set; }
    }
}