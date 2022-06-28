using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBibloteca.Models.DTO
{
    public class EditorialCreacionDto
    {
        [Required]
        public string Nombre { get; set; }
    }
}
