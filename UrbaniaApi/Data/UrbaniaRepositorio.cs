using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrbaniaApi.Models;

namespace UrbaniaApi.Data
{
    public class UrbaniaRepositorio : IUrbaniaRepositorio
    {
        public DataContext _context { get; }
        public UrbaniaRepositorio(DataContext context)
        {
            _context = context;

        }
        public void Agregar<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Eliminar<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> GuardarTodo()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Foto> ObtenerFoto(int id)
        {
            var foto = await _context.Foto.FirstOrDefaultAsync(f => f.Id == id);
            return foto;
        }

        public async Task<Proyecto> ObtenerProyecto(int id)
        {
           var proyecto = await _context.Proyectos.FirstOrDefaultAsync(p => p.Id == id);
           return proyecto;
        }

        public async Task<IEnumerable<Proyecto>> ObtenerProyectos()
        {
            var proyectos = await _context.Proyectos.ToListAsync();
            return proyectos;
        }
    }
}