using System.Collections.Generic;
using System.Threading.Tasks;
using UrbaniaApi.Models;

namespace UrbaniaApi.Data
{
    public interface IUrbaniaRepositorio
    {
        void Agregar<T>(T entity) where T: class;
        void Eliminar<T>(T entity) where T: class;
        Task<bool> GuardarTodo();
      
       
        Task<Foto> ObtenerFoto(int id);
               
       Task<IEnumerable<Proyecto>> ObtenerProyectos();
        Task<Proyecto> ObtenerProyecto(int id);
    }
}