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
    [Route("api/criterio")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CriterioController
    {
        private readonly Unidad_VictimaContext context;

        private readonly IMapper mapper;

        public CriterioController(Unidad_VictimaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CriterioDTO>>> Get()
        {
            var entidades = await context.TblCriterios.ToListAsync();
            return mapper.Map<List<CriterioDTO>>(entidades);

        }

        [HttpGet("{id:int}", Name = "ObtenerCriterio")]
        public async Task<ActionResult<CriterioDTO>> Get(int id)
        {

            var entidade = await context.TblCriterios.FirstOrDefaultAsync(X => X.Id == id);
            if (entidade == null)
            {
                return NotFound();
            }

            return mapper.Map<CriterioDTO>(entidade);
        }

        [HttpGet("{idAT:int}", Name = "ObtenerCriterioAT")]
        public async Task<ActionResult<CriterioDTO>> GetCriterio(int idAT)
        {

            var entidade = await context.TblCriterios.FirstOrDefaultAsync(X => X.IdAt == idAT);
            if (entidade == null)
            {
                return NotFound();
            }

            return mapper.Map<CriterioDTO>(entidade);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CriterioDTO criterioDTO)
        {

            var entidad = mapper.Map<TblCriterio>(criterioDTO);

            context.Add(entidad);

            await context.SaveChangesAsync();

            var Criterio_DTO = mapper.Map<CriterioDTO>(entidad);

            return new CreatedAtRouteResult("ObtenerCriterio", new { id = Criterio_DTO.Id }, Criterio_DTO);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CriterioDTO criterioDTO)
        {
            var entidad = mapper.Map<TblCriterio>(criterioDTO);

            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();

            var Criterio_DTO = mapper.Map<CriterioDTO>(entidad);

            return new CreatedAtRouteResult("ObtenerCriterio", new { id = Criterio_DTO.Id }, Criterio_DTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CriterioDTO>> Delete(int id)
        {
            var existe = await context.TblCriterios.AnyAsync(X => X.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new TblCriterio() { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }

        private ActionResult<CriterioDTO> NoContent()
        {
            throw new NotImplementedException();
        }

        private ActionResult<CriterioDTO> NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
