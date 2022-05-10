using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_AT.DTOs;
using WebApp_AT.Models;

namespace WebApp_AT.Controllers
{
    [ApiController]
    [Route("api/municipio")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MunicipioController : ControllerBase
    {
        private readonly RECVContext context;

        private readonly IMapper mapper;

        public MunicipioController(RECVContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MunicipioDTO>>> Get()
        {
            var entidad = await context.TblMunicipios.ToListAsync();
            return mapper.Map<List<MunicipioDTO>>(entidad);

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MunicipioDTO>> GetMunicipio(int id)
        {

            var entidad = await context.TblMunicipios.FirstOrDefaultAsync(X => X.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }

            return mapper.Map< MunicipioDTO>(entidad);
        }

        [HttpGet("ObtenerMunicipioDPTO/{idDpto:int}")]
        public async Task<ActionResult<List<MunicipioDTO>>> GetMunicipioDPTO(int idDpto)
        {

            var entidad = await context.TblMunicipios.Where(X => X.IdDpto == idDpto)
                                                     .OrderBy(X => X.IdDpto)
                                                     .ToListAsync();
            if (entidad == null)
            {
                return NotFound();
            }

            return mapper.Map<List<MunicipioDTO>>(entidad);
        }
    }
}
