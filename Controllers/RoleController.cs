using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_AT.DTOs;
using WebApp_AT.Models;

namespace WebApp_AT.Controllers
{
        [ApiController]
        [Route("api/roles")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public class RoleController : ControllerBase
        {
            private readonly RECVContext context;

            private readonly IMapper mapper;

            public RoleController(RECVContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }


        [HttpGet]
        public async Task<ActionResult<List<RolesDTO>>> Get()
        {
            var entidad = await context.TblRoles.ToListAsync();
            return mapper.Map<List<RolesDTO>>(entidad);

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RolesDTO>> GetMunicipio(int id)
        {

            var entidad = await context.TblRoles.FirstOrDefaultAsync(X => X.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }

            return mapper.Map<RolesDTO>(entidad);
        }
    }
}
