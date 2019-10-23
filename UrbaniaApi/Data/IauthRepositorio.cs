using System.Threading.Tasks;
using UrbaniaApi.Models;

namespace UrbaniaApi.Data
{
    public interface IauthRepositorio
    {
         Task<Usuario> Registro(Usuario usuario, string password);
         Task<Usuario> Login(string nombre , string password);

         Task<bool> ExisteUsuario(string nombre);
    }
}