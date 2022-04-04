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
    [Route("api/remitente")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class RemitenteController
    {
        private readonly Unidad_VictimaContext context;

        private readonly IMapper mapper;

        public RemitenteController(Unidad_VictimaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<RemitenteDTO>>> Get()
        {
            var entidades = await context.TblRemitentes.ToListAsync();
            return mapper.Map<List<RemitenteDTO>>(entidades);

        }

        [HttpGet("ObtenerRemitenteNOMBRE/{nombreR}")]
        public async Task<ActionResult<List<RemitenteDTO>>> GetRemitente(string nombreR)
        {
            // var entidades = await context.TblRemitentes.ToListAsync();
            var entidades = await context.TblRemitentes.Where(X => X.NombreRemitente.Contains(nombreR))
                                                       .OrderBy(X => X.NombreRemitente)
                                                       .ToListAsync();

            return mapper.Map<List<RemitenteDTO>>(entidades);

        }

        [HttpGet("{id:int}", Name = "ObtenerRemitente")]
        public async Task<ActionResult<RemitenteDTO>> Get(int id)
        {

            var entidade = await context.TblRemitentes.FirstOrDefaultAsync(X => X.Id == id);
            if (entidade == null)
            {
                return NotFound();
            }

            return mapper.Map<RemitenteDTO>(entidade);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RemitenteDTO remitenteDTO)
        {

            var entidad = mapper.Map<TblRemitente>(remitenteDTO);
            entidad.Fecha = DateTime.Now;

            context.Add(entidad);

            await context.SaveChangesAsync();

            var remitente_DTO = mapper.Map<RemitenteDTO>(entidad);

            //var TblR = new TblRemitente
            //{
            //    Id = remitente_DTO.Id,
            //};

            return new CreatedAtRouteResult("ObtenerRemitente", new { id = remitente_DTO.Id }, remitente_DTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RemitenteDTO remitenteDTO)
        {
            var entidad = mapper.Map<TblRemitente>(remitenteDTO);

            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();

            var remitente_DTO = mapper.Map<RemitenteDTO>(entidad);

            return new CreatedAtRouteResult("ObtenerRemitente", new { id = remitente_DTO.Id }, remitente_DTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RemitenteDTO>> Delete(int id)
        {
            var existe = await context.TblAlertasTempranas.AnyAsync(X => X.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new TblAlertasTemprana() { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }

        private ActionResult<RemitenteDTO> NoContent()
        {
            throw new NotImplementedException();
        }

        private ActionResult<RemitenteDTO> NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
