using Microsoft.AspNetCore.Http;
using WebApp_AT.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_AT.Validaciones
{
    public class TipoArchivoValidacion : ValidationAttribute
    {

        private readonly string[] tiposValidos;

        public TipoArchivoValidacion(string[] tiposValidos)
        {
            this.tiposValidos = tiposValidos;
        }

        public TipoArchivoValidacion(GrupoTipoArchivo grupoTipoArchivo)
        {
            if (grupoTipoArchivo == GrupoTipoArchivo.Archivo)
            {
                tiposValidos = new string[] { "application/pdf" };
            }
        }



        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if (!tiposValidos.Contains(formFile.ContentType))
            {
                return new ValidationResult($" el tipo  del archivo debe ser  {string.Join(", ", tiposValidos)} ");
            }

            return ValidationResult.Success;
        }

    }
}
