using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_AT.Validaciones
{
    public class ValidacionArchivo:ValidationAttribute
    {
        private readonly int  validacionArchivoBbyte;


        public ValidacionArchivo(int ValidacionArchivoBbyte)
        {
            validacionArchivoBbyte = ValidacionArchivoBbyte;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value== null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if (formFile.Length > validacionArchivoBbyte * 2024 * 2024)
            {
                return new ValidationResult($" el peso del archivo no puede ser mayor {validacionArchivoBbyte} mb");
            }

            return ValidationResult.Success;
        }
    }
}
