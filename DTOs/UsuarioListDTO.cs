using System;

namespace WebApp_AT.DTOs
{
    public class UsuarioListDTO
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public string Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public bool? Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
