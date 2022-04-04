using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblArchivosCaso
    {
        public int Id { get; set; }
        public int IdCasos { get; set; }
        public string NombreArchivo { get; set; }
        public string RutaArchivo { get; set; }
        public string TipoArchivo { get; set; }
        public string TamanioArchivo { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual TblAlertasTemprana IdCasosNavigation { get; set; }
    }
}
