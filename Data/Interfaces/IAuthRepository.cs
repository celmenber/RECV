using System.Threading.Tasks;
using WebApp_AT.Models;

namespace WebApp_AT.Data.Interfaces
{
    public interface IAuthRepository
    {
        Task<TblUsuario> Register(TblUsuario Usuario, string Passwordhash);
        Task<TblUsuario> Login(string Usuario, string Passwordhash);
        Task<bool> UserExists(string Usuario);
    }
}
