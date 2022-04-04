using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_AT.DTOs
{
    public class UnidadminimageoDTO
    {
        [Key]
        public int Id { get; set; }
        public int IdMunicipio { get; set; }
        public string Nombre { get; set; }
    }
}
