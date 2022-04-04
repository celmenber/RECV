using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_AT.DTOs;
using WebApp_AT.Models;

namespace WebApp_AT.Controllers
{
    [ApiController]
    [Route("api/unidadminimageo")]
    public class UnidadminimageoController : ControllerBase
    {
        private readonly Unidad_VictimaContext context;

        private readonly IMapper mapper;

        public UnidadminimageoController(Unidad_VictimaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UnidadminimageoDTO>>> GetUnidadminimageo()
        {
            var entidades = await context.TblUnidadMinimaGeos.ToListAsync();
            var Dtos = mapper.Map<List<UnidadminimageoDTO>>(entidades);
            return Dtos;

        }

        [HttpGet("{id:int}", Name = "ObtenerUnidadminimageo")]
        public async Task<ActionResult<UnidadminimageoDTO>> GetUnidadminimageo(int id)
        {

            var entidade = await context.TblUnidadMinimaGeos.FirstOrDefaultAsync(X => X.Id == id);
            if (entidade == null)
            {
                return NotFound();
            }

            return mapper.Map<UnidadminimageoDTO>(entidade);
        }

        [HttpGet("ObtenerUnidadminimageoMunic/{idMunicipio:int}", Name = "ObtenerUnidadminimageoMunic")]
        public async Task<ActionResult<UnidadminimageoDTO>> UnidadminimageoMunic(int idMunicipio)
        {

            var entidade = await context.TblUnidadMinimaGeos.Where(X => X.IdMunicipio == idMunicipio)
                                                      .OrderBy(X => X.IdMunicipio)
                                                      .ToListAsync();
            if (entidade == null)
            {
                return NotFound();
            }

            return mapper.Map<UnidadminimageoDTO>(entidade);
        }

        [HttpGet("ObtenerumgNOMBRE/{nombreUMG}")]
        public async Task<ActionResult<List<UnidadminimageoDTO>>> GetRemitente(string nombreUMG)
        {
            // var entidades = await context.TblRemitentes.ToListAsync();
            var entidades = await context.TblUnidadMinimaGeos.Where(X => X.Nombre.Contains(nombreUMG))
                                                       .OrderBy(X => X.Nombre)
                                                       .ToListAsync();

            return mapper.Map<List<UnidadminimageoDTO>>(entidades);

        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UnidadminimageoDTO unidadminimageoDTO)
        {

            var entidad = mapper.Map<TblUnidadMinimaGeo>(unidadminimageoDTO);

            context.Add(entidad);

            await context.SaveChangesAsync();

            var mingeo_DTO = mapper.Map<UnidadminimageoDTO>(entidad);

            return new CreatedAtRouteResult("ObtenerUnidadminimageo", new { id = mingeo_DTO.Id }, mingeo_DTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UnidadminimageoDTO unidadminimageoDTO)
        {
            var entidad = mapper.Map<TblUnidadMinimaGeo>(unidadminimageoDTO);

            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();

            var mingeo_DTO = mapper.Map<UnidadminimageoDTO>(entidad);

            return new CreatedAtRouteResult("ObtenerAT", new { id = mingeo_DTO.Id }, mingeo_DTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.TblUnidadMinimaGeos.AnyAsync(X => X.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new TblUnidadMinimaGeo() { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
