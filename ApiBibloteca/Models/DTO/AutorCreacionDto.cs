using ApiBibloteca.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBibloteca.Models.DTO
{
    public class AutorCreacionDto
    {
        public string Nombre { get; set; }

        [ExtensionFileAttribute(new[] { "image/png", "image/jpeg", "image/gif" })]
        [WeightFile(1024)]
        public IFormFile Foto { get; set; }
    }
}
