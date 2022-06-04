using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpGet("FiltrosAT")]
        public async Task<ActionResult<List<AlertasTempranaDTO>>> Filtrar([FromQuery] AlertasTFiltrosDTO alertasTFiltrosDTO)
        {

            var AlertasTFiltros = context.TblAlertasTempranas.AsQueryable();

            if (alertasTFiltrosDTO.Options == "1")
            {
                if (alertasTFiltrosDTO.Check == "0")
                {
                    AlertasTFiltros = AlertasTFiltros.Where(x => x.Fecha >= alertasTFiltrosDTO.FechaIni && x.Fecha <= alertasTFiltrosDTO.FechaFin);
                }

                if (alertasTFiltrosDTO.Check == "1")
                {
                    AlertasTFiltros = AlertasTFiltros.Where(x => x.FechaDocumento >= alertasTFiltrosDTO.FechaIni && x.FechaDocumento <= alertasTFiltrosDTO.FechaFin);
                }

            }

            

            if (!string.IsNullOrEmpty(alertasTFiltrosDTO.NumeroRadicado) && alertasTFiltrosDTO.Options == "2")
            {
                AlertasTFiltros = AlertasTFiltros.Where(x => x.NumeroRadicado == alertasTFiltrosDTO.NumeroRadicado);
            }

            if (alertasTFiltrosDTO.Departamento != 0 && alertasTFiltrosDTO.Options == "3")
            {
                if (alertasTFiltrosDTO.Departamento != 0 && alertasTFiltrosDTO.Municipio == 0)
                {
                  AlertasTFiltros = AlertasTFiltros.Where(x => x.IdDpto == alertasTFiltrosDTO.Departamento);
                }

                if (alertasTFiltrosDTO.Departamento != 0 && alertasTFiltrosDTO.Municipio != 0)
                {
                    AlertasTFiltros = AlertasTFiltros.Where(x => x.IdMunicipio == alertasTFiltrosDTO.Municipio);
                }

            }


            var ATFiltros = await AlertasTFiltros.ToListAsync();
            return mapper.Map<List<AlertasTempranaDTO>>(ATFiltros);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AlertasTCreacionDTO alertasTCreacionDTO)
        {
            var validaRad = await context.TblAlertasTempranas.AnyAsync(x => x.NumeroRadicado == alertasTCreacionDTO.NumeroRadicado);

            if (validaRad)
                return Ok(new
                {
                    status = 400,
                    Msg = "Numero Radicado ya existe"
                });

            var entidad = mapper.Map<TblAlertasTemprana>(alertasTCreacionDTO);
          
            entidad.Fecha = DateTime.Now;

            context.Add(entidad);

            await context.SaveChangesAsync();

            var at_DTO = mapper.Map<AlertasTempranaDTO>(entidad);

            var respuesta = new
            {
                status = HttpStatusCode.OK,
                id = at_DTO.Id,
                numRadicado = at_DTO.NumeroRadicado
            };

            return Ok(respuesta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AlertasTCreacionDTO alertasTCreacionDTO)
        {

            var entidad = mapper.Map<TblAlertasTemprana>(alertasTCreacionDTO);

            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();

            var at_DTO = mapper.Map<AlertasTempranaDTO>(entidad);

            var entidad_DTO =  new CreatedAtRouteResult("ObtenerAT", new { id = at_DTO.Id }, at_DTO);

            var respuesta = new
            {
                status = HttpStatusCode.OK,
                entidad = entidad_DTO
            };

            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.TblAlertasTempranas.AnyAsync(X => X.Id == id);

            if (!existe)
            {
                return NotFound();
            }


            var remove = context.Remove(new TblAlertasTemprana() { Id = id });

            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //if (ex.InnerException != null &&
                //ex.InnerException.InnerException != null)
                //{
                //    return status = 404;
                //}
                
                return BadRequest(new
                {
                    status = 404
                });

            }
          
            var respuesta = new
            {
                status = HttpStatusCode.Accepted
            };

            return Ok(respuesta);
        }

    }
}
