using System;

namespace WebApp_AT.DTOs
{
    public class AlertasTFiltrosDTO
    {
        public string NumeroRadicado { get; set; }
        public int Departamento { get; set; }
        public int Municipio { get; set; }
        public DateTime? FechaIni { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Options { get; set; }
        public string Check { get; set; }
    }
}
