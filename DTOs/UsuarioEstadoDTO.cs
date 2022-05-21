using System;

namespace WebApp_AT.DTOs
{
    public class UsuarioEstadoDTO
    {
        public bool? Estado { get; set; }
        public DateTime Fecha { get; set; }

        public UsuarioEstadoDTO()
        {
            Fecha = DateTime.Now;
        }
    }
}
