using ApiBibloteca.Models;
using ApiBibloteca.Models.DTO;
using ApiBibloteca.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBibloteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ExtendedBaseController<CategoriaCreacionDto, Categoria, CategoriaDto>
    {
        private readonly BiblotecaDBContext _biblotecaDb;
        private readonly IMapper _mapper;
        public CategoriaController(BiblotecaDBContext biblotecaDBContext, IMapper mapper)
            :base(biblotecaDBContext, mapper, "Categoria")
        {
            _biblotecaDb = biblotecaDBContext;
            _mapper = mapper;
        }

        

        
    }
}
