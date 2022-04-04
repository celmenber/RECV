using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp_AT.Validaciones;

namespace WebApp_AT.DTOs
{
    public class ArchivoscreacionDTO
    {
        public int IdCasos { get; set; }
        public string NombreArchivo { get; set; }
        public string TipoArchivo { get; set; }
        public string TamanioArchivo { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
