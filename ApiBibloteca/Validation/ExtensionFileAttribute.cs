using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBibloteca.Validation
{
    public class ExtensionFileAttribute : ValidationAttribute
    {
        private readonly string[] tiposValidos;

        public ExtensionFileAttribute(string[] tiposValidos)
        {
            this.tiposValidos = tiposValidos;
        }

        /*public ExtensionFileAttribute(TipoArchivo tipoArchivo)
        {
            if(tipoArchivo == TipoArchivo.Image)
            {
                tiposValidos = new[] { "image/png", "image.jpg", "image/gif" };
            }
        }*/
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var formFile = value as IFormFile;
            if(formFile != null)
            {
                if (!tiposValidos.Contains(formFile.ContentType))
                {
                    return new ValidationResult($"Los tipos validos son {string.Join(",", tiposValidos)}");
                }

            }
            return ValidationResult.Success;
        }
    }
}
