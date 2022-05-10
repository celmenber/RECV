using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/alertatemprana")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AlertasTempranaController:ControllerBase
    {
        private readonly RECVContext context;

        private readonly IMapper mapper;

        public AlertasTempranaController(RECVContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AlertasTempranaDTO>>> Get()
        {
            var Hoy = DateTime.Today;
            var entidades = await context.TblAlertasTempranas.Where(X => X.Fecha >= Hoy)
                                                     .OrderBy(X => X.Id)
                                                     .ToListAsync();
            var Dtos = mapper.Map<List<AlertasTempranaDTO>>(entidades);
            return Dtos;

        }

        [HttpGet("{id:int}", Name = "ObtenerAT")]
        public async Task<ActionResult<AlertasTempranaDTO>> Get(int id)
        {

            var entidade = await context.TblAlertasTempranas.FirstOrDefaultAsync(X => X.Id == id);
            if (entidade == null)
            {
                return NotFound();
            }

            var AT_Dto = mapper.Map<AlertasTempranaDTO>(entidade);
            return AT_Dto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AlertasTCreacionDTO alertasTCreacionDTO)
        {

            var entidad = mapper.Map<TblAlertasTemprana>(alertasTCreacionDTO);
          
            entidad.Fecha = DateTime.Now;
            context.Add(entidad);

            await context.SaveChangesAsync();

            var at_DTO = mapper.Map<AlertasTempranaDTO>(entidad);

            return new CreatedAtRouteResult("ObtenerAT", new { id = at_DTO.Id }, at_DTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AlertasTCreacionDTO alertasTCreacionDTO)
        {
            var entidad = mapper.Map<TblAlertasTemprana>(alertasTCreacionDTO);

            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();

            var at_DTO = mapper.Map<AlertasTempranaDTO>(entidad);

            return new CreatedAtRouteResult("ObtenerAT", new { id = at_DTO.Id }, at_DTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
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

    }
}
