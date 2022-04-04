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
    [Route("api/conductascriterio")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ConductasCriterioController
    {
        private readonly Unidad_VictimaContext context;

        private readonly IMapper mapper;

        public ConductasCriterioController(Unidad_VictimaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConductasCriterioDTO>>> Get()
        {
            var entidad = await context.TblConductasCriterios.ToListAsync();
            return mapper.Map<List<ConductasCriterioDTO>>(entidad);

        }

        [HttpGet("{id:int}", Name = "Obtener_CC")]
        public async Task<ActionResult<ConductasCriterioDTO>> Get(int id)
        {

            var entidade = await context.TblConductasCriterios.FirstOrDefaultAsync(X => X.Id == id);
            if (entidade == null)
            {
                return NotFound();
            }

            return mapper.Map<ConductasCriterioDTO>(entidade);
        }

       

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ConductasCriterioDTO conductacriterioDTO)
        {

            var entidad = mapper.Map<TblConductasCriterio>(conductacriterioDTO);

            context.Add(entidad);

            await context.SaveChangesAsync();

            var cc_DTO = mapper.Map<ConductasCriterioDTO>(entidad);


            return new CreatedAtRouteResult("Obtener_CC", new { id = cc_DTO.Id }, cc_DTO);
        }

        //private ActionResult Ok()
        //{
        //    throw new NotImplementedException();
        //}

        private ActionResult<ConductasCriterioDTO> NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
