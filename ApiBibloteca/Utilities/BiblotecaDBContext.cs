using ApiBibloteca.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBibloteca.Utilities
{
    public class BiblotecaDBContext : DbContext
    {
        public BiblotecaDBContext(DbContextOptions<BiblotecaDBContext> options) : base(options)
        {

        }

        //Se agrega como propiedad de DbSet las tablas que se requieran agregar por migración a la BD.
        //Para agregar una Tabla se puede seguir como ejemplo el primer atributo DbSet abajo
        //Donde se debe agregar un atributo DbSet reemplazando la palabra "Categoria"
        //por el nombre de la clase que se realizo, Con los atributos que tendrá la tabla en la BD,
        //asi mismo se debe reemplazar "Categorias", por alguna palabra alusiva a la tabla que se desea crear.
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Autor> Autores { get; set; }
    }
}
