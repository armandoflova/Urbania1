using System.ComponentModel.DataAnnotations;

namespace UrbaniaApi.Dtos
{
    public class UsuarioRegistro
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        
    }
}