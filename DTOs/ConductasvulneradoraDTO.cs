using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_AT.DTOs
{
    public class ConductasvulneradoraDTO
    {   [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
