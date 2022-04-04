using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_AT.DTOs
{
    public class RemitenteDTO
    {
        [Key]
        public int Id { get; set; }
        public string NombreRemitente { get; set; }
        public string Email { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
