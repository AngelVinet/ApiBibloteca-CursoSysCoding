using ApiBibloteca.Models;
using ApiBibloteca.Models.DTO;
using ApiBibloteca.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBibloteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialesController : ExtendedBaseController<EditorialCreacionDto, Editorial, EditorialDto>
    {
        private readonly BiblotecaDBContext _biblotecaDb;
        private readonly IMapper _mapper;
        public EditorialesController(BiblotecaDBContext biblotecaDB, IMapper mapper)
            :base(biblotecaDB, mapper, "Editoriales")
        {
            _biblotecaDb = biblotecaDB;
            _mapper = mapper;
        }
    }
}
