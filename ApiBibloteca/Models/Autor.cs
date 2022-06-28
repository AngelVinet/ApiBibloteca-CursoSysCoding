using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBibloteca.Models
{
    public class Autor : IHaveId
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
    }
}
