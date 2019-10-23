using System;
using System.Collections.Generic;

namespace UrbaniaApi.Dtos
{
    public class ProyectoReturn
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Mostrar { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public virtual ICollection<FotoReturn> Fotos { get; set; }
    }
}