using System;

namespace UrbaniaApi.Models
{
    public class Foto
    {
        public int Id { get; set; } 
        public string Url { get; set; }
        public Proyecto Proyecto { get; set; }
        public int ProyectoId { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool esPrincipal { get; set; }
    }
}