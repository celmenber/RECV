using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApp_AT.Data.Interfaces;
using WebApp_AT.Models;

namespace WebApp_AT.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly RECVContext _context;

        public AuthRepository(RECVContext context)
        {
            this._context = context;
        }

        public async Task<TblUsuario> Login(string Usuario, string Passwordhash)
        {
  
            var usuario = await _context.TblUsuarios.FirstOrDefaultAsync(x => x.Usuario == Usuario);

            if (usuario == null)
                return null;

           if (!VerifyPasswordHash(Passwordhash, usuario.Passwordhash, usuario.Passwordsalt))
                return null;
            

            return usuario;
        }
        private bool VerifyPasswordHash(string password, string passwordhash, string passwordsalt)
        {

            var computedHash = GetSHA256(password);

            if (computedHash != passwordhash) return false;

            return true;
        }
        public async Task<TblUsuario> Register(TblUsuario usuario, string password)
        {

              usuario.Passwordhash = GetSHA256(password);
              //usuario.Passwordsalt = GetSHA256(password);

              await _context.TblUsuarios.AddAsync(usuario);
              await _context.SaveChangesAsync();

            return usuario;
        }

        private string GetSHA256(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public async Task<bool> UserExists(string usuario)
        {
            if (await _context.TblUsuarios.AnyAsync(x => x.Usuario == usuario))
                return true;

            return false;
        }
    }
}
