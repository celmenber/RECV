using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_AT.Validaciones;

namespace WebApp_AT.DTOs
{
    public class ArchivospathDTO : ArchivoscreacionDTO
    {
        [ValidacionArchivo(ValidacionArchivoBbyte: 3)]
        [TipoArchivoValidacion(grupoTipoArchivo: GrupoTipoArchivo.Archivo)]
        public IFormFile RutaArchivo { get; set; }
    }
}
