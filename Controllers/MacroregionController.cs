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
    [Route("api/macroregion")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MacroregionController: ControllerBase
    {
        private readonly RECVContext context;

        private readonly IMapper mapper;

        public MacroregionController(RECVContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MacroregionDTO>>> Get()
        {
            var entidad = await context.TblMacroregions.ToListAsync();
            return mapper.Map<List<MacroregionDTO>>(entidad);

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MacroregionDTO>> GetMunicipio(int id)
        {

            var entidad = await context.TblMacroregions.FirstOrDefaultAsync(X => X.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }

            return mapper.Map<MacroregionDTO>(entidad);
        }
    }
}
