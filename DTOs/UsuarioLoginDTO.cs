using System.ComponentModel.DataAnnotations;

namespace WebApp_AT.DTOs
{
    public class UsuarioLoginDTO
    {
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Passwordhash { get; set; }
    }
}
