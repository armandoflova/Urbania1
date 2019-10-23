using System.Collections.Generic;

namespace UrbaniaApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PassworSalt { get; set; }
        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}