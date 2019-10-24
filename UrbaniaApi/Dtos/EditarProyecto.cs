using System;

namespace UrbaniaApi.Dtos
{
    public class EditarProyecto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Mostrar { get; set; }
       
        public int UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}