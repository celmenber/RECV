using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp_AT.DTOs
{
    public class AlertasTEdicionDTO
    {
        [Key]
        public int IdRemitente { get; set; }
        public string NumeroRadicado { get; set; }
        public DateTime FechaDocumento { get; set; }
        public string Asunto { get; set; }
        public int IdDpto { get; set; }
        public int IdMunicipio { get; set; }
        public int? IdUmg { get; set; }
    }
}
