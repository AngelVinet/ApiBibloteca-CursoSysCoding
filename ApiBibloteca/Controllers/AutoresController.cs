using ApiBibloteca.Models;
using ApiBibloteca.Models.DTO;
using ApiBibloteca.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBibloteca.Controllers
{
    [Route("api/Autores")]
    [ApiController]
    public class AutoresController : ExtendedBaseController<AutorCreacionDto, Autor, AutorDto>
    {
        private readonly BiblotecaDBContext biblotecaDBContext;
        private readonly IMapper mapper;
        private readonly IAlmacenador almacenador;

        public AutoresController(BiblotecaDBContext biblotecaDBContext, IMapper mapper, IAlmacenador almacenador)
            :base(biblotecaDBContext, mapper, "Autores")
        {
            this.biblotecaDBContext = biblotecaDBContext;
            this.mapper = mapper;
            this.almacenador = almacenador;
        }

        public async override Task<ActionResult> Post([FromForm]AutorCreacionDto creationDto)
        {
            var entity = mapper.Map<Autor>(creationDto);
            if(creationDto.Foto != null)
            {
                string fotoUrl = await GuardarFoto(creationDto.Foto);
                entity.Foto = fotoUrl;
            }
            biblotecaDBContext.Add(entity);
            await biblotecaDBContext.SaveChangesAsync();
            var dto = mapper.Map<AutorDto>(entity);

            return new CreatedAtActionResult(nameof(Get), "Autores", new { id = entity.Id }, dto);
        }

        public async override Task<ActionResult> Put(int id, [FromForm]AutorCreacionDto creacionDto)
        {
            var entity = await biblotecaDBContext.Autores.FirstOrDefaultAsync(a => a.Id == id);
            if(entity == null)
            {
                return NotFound();
            }
            mapper.Map(creacionDto, entity);
            if(creacionDto.Foto != null)
            {
                if (!string.IsNullOrEmpty(entity.Foto))
                {
                    await almacenador.Borrar(entity.Foto, Constantes.ContenedoresArchivos.contenedorAutores);
                }
                string fotoUrl = await GuardarFoto(creacionDto.Foto);
                entity.Foto = fotoUrl;
            }
            biblotecaDBContext.Entry(entity).State = EntityState.Modified;
            await biblotecaDBContext.SaveChangesAsync();
            return NoContent();

        }

        public async override Task<ActionResult> Delete(int id)
        {
            var entity = await biblotecaDBContext.Autores.FirstOrDefaultAsync(a => a.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(entity.Foto))
            {
                await almacenador.Borrar(entity.Foto, Constantes.ContenedoresArchivos.contenedorAutores);
            }
            return await base.Delete(id);
        }

        private async Task<string> GuardarFoto(IFormFile foto)
        {
            using var stream = new MemoryStream();
            await foto.CopyToAsync(stream);
            var bytes = stream.ToArray();
            return await almacenador.Crear(bytes, foto.ContentType, Path.GetExtension(foto.FileName), Constantes.ContenedoresArchivos.contenedorAutores,Guid.NewGuid().ToString());
        }
    }
}
