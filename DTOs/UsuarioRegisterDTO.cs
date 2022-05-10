using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp_AT.DTOs
{
    public class UsuarioRegisterDTO
    {
        
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "El password debe tener entre 4 y 8 characteres")]
        public string Passwordhash { get; set; }
        [Required]
        public int IdRol { get; set; }
        public bool? Estado { get; set; }
        public DateTime Fecha { get; set; }
       

        public UsuarioRegisterDTO()
        {
            Fecha = DateTime.Now;
            Estado = true;
        }
    }
}
