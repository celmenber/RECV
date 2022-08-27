using System.ComponentModel.DataAnnotations;

namespace WebApp_AT.DTOs
{
    public class RolesDTO
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
