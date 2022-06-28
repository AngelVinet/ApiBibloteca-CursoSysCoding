using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBibloteca.Validation
{
    //Buena practica es que las clases de validaciones de atributos terminen con la palabra attribute
    public class WeightFileAttribute : ValidationAttribute
    {
        private readonly double pesoArchivoKB;

        public WeightFileAttribute(double pesoArchivoKB)
        {
            this.pesoArchivoKB = pesoArchivoKB;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var formFile = value as IFormFile;
            if(formFile != null)
            {
                if(formFile.Length / 1024 > pesoArchivoKB)
                {
                    return new ValidationResult($"El peso máximó para el archivo que envias es de {pesoArchivoKB} KB" +
                        $"sin embargo has enviado un archivo de {formFile.Length/1024} KB");
                }
            }
            return ValidationResult.Success;
        }
    }
}
