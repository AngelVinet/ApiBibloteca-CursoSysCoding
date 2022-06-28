using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBibloteca.Utilities
{
    public interface IAlmacenador
    {
        public Task<string> Crear(byte[] file, string contentType, string extension, string container, string name);
        public Task Borrar(string ruta, string container);
    }
}
