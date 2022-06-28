using ApiBibloteca.Models;
using ApiBibloteca.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBibloteca.Utilities
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            //-----------Categorias-------------------------#
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<CategoriaCreacionDto, Categoria>();

            //---------Editoriales------------------------#
            CreateMap<Editorial, EditorialDto>().ReverseMap();
            CreateMap<EditorialCreacionDto, Editorial>();

            //---------Autores------------------------#
            CreateMap<Autor, AutorDto>().ReverseMap();
            CreateMap<AutorCreacionDto, Autor>()
                .ForMember(m => m.Foto, options => options.Ignore());
        }
    }
}
