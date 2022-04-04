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
    [Route("api/conductas")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ConductasvulneradoraController
    {
        private readonly Unidad_VictimaContext context;

        private readonly IMapper mapper;

        public ConductasvulneradoraController(Unidad_VictimaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConductasvulneradoraDTO>>> GetConductasAll()
        {
            var entidades = await context.TblConductasVulneradoras.ToListAsync();
            return mapper.Map<List<ConductasvulneradoraDTO>>(entidades);

        }

        [HttpGet("{id:int}", Name = "ObtenerCONDUCTAS")]
        public async Task<ActionResult<ConductasvulneradoraDTO>> GetConductas(int id)
        {

            var entidade = await context.TblConductasVulneradoras.FirstOrDefaultAsync(X => X.Id == id);
            if (entidade == null)
            {
                return NotFound();
            }

            return mapper.Map<ConductasvulneradoraDTO>(entidade);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ConductasvulneradoraDTO conductasvulneradoraDTO)
        {

            var entidad = mapper.Map<TblConductasVulneradora>(conductasvulneradoraDTO);

            entidad.Fecha = DateTime.Now;

            context.Add(entidad);

            await context.SaveChangesAsync();

            var CV_DTO = mapper.Map<ConductasvulneradoraDTO>(entidad);

            return new CreatedAtRouteResult("ObtenerCONDUCTAS", new { id = CV_DTO.Id }, CV_DTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ConductasvulneradoraDTO conductasvulneradoraDTO)
        {
            var entidad = mapper.Map<TblCriterio>(conductasvulneradoraDTO);

            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();

            var CV_DTO = mapper.Map<ConductasvulneradoraDTO>(entidad);

            return new CreatedAtRouteResult("ObtenerCONDUCTAS", new { id = CV_DTO.Id }, CV_DTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ConductasvulneradoraDTO>> Delete(int id)
        {
            var existe = await context.TblConductasVulneradoras.AnyAsync(X => X.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new TblCriterio() { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }

        private ActionResult<ConductasvulneradoraDTO> NoContent()
        {
            throw new NotImplementedException();
        }

        private ActionResult<ConductasvulneradoraDTO> NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
