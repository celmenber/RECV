using WebApp_AT.Models;

namespace WebApp_AT.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(TblUsuario usuario);
    }
}
