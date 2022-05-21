using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_AT.DTOs
{
    public class AlertasTCreacionDTO
    {
        [Key]
        public int IdRemitente { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroRadicado { get; set; }
        public DateTime FechaDocumento { get; set; }
        public string Asunto { get; set; }
        public int IdDpto { get; set; }
        public int IdMunicipio { get; set; }
        public int? IdUmg { get; set; }
    }
}
