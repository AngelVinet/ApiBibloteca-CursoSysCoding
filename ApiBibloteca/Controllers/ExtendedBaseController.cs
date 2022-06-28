using ApiBibloteca.Models;
using ApiBibloteca.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBibloteca.Controllers
{
    public class ExtendedBaseController<TCreation, TEntity, TDto> : ControllerBase
        where TEntity : class, IHaveId
    {
        private readonly BiblotecaDBContext _biblotecaDb;
        private readonly IMapper _mapper;
        private readonly string _controllerName;
        public ExtendedBaseController(BiblotecaDBContext biblotecaDB, IMapper mapper, string controllerName)
        {
            _biblotecaDb = biblotecaDB;
            _mapper = mapper;
            _controllerName = controllerName;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TDto>>> Get()
        {
            var entidad = await _biblotecaDb.Set<TEntity>().ToListAsync();

            return _mapper.Map<List<TDto>>(entidad);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TDto>> Get(int id)
        {
            var entidad = await _biblotecaDb.Set<TEntity>().FirstOrDefaultAsync(c => c.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<TDto>(entidad);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Post(TCreation creationDto)
        {
            var entidad = _mapper.Map<TEntity>(creationDto);
            _biblotecaDb.Add(entidad);
            await _biblotecaDb.SaveChangesAsync();
            var dto = _mapper.Map<TDto>(entidad);
            return new CreatedAtActionResult(nameof(Get),_controllerName, new { id = entidad.Id }, dto);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Put(int id, TCreation creacionDto)
        {
            var entidad = await _biblotecaDb.Set<TEntity>().FirstOrDefaultAsync(c => c.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }
            _mapper.Map(creacionDto, entidad);
            _biblotecaDb.Entry(entidad).State = EntityState.Modified;
            await _biblotecaDb.SaveChangesAsync();
            return Ok(entidad);

        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var entidad = await _biblotecaDb.Set<TEntity>().FirstOrDefaultAsync(c => c.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }
            _biblotecaDb.Entry(entidad).State = EntityState.Deleted;
            await _biblotecaDb.SaveChangesAsync();
            return NoContent();
        }
    }

}

