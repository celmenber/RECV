﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_AT.DTOs;
using WebApp_AT.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebApp_AT.Controllers
{
    [ApiController]
    [Route("api/departamento")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DepartamentoController : ControllerBase
    {
        private readonly RECVContext context;

        private readonly IMapper mapper;

        public DepartamentoController(RECVContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<DepartamentoDTO>>> GetDepartamentoAll()
        {
            var entidades = await context.TblDepartamentos.ToListAsync();
            return mapper.Map<List<DepartamentoDTO>>(entidades);

        }

        [HttpGet("{id:int}", Name = "ObtenerDPTO")]
        public async Task<ActionResult<DepartamentoDTO>> GetDepartamento(int id)
        {

            var entidade = await context.TblDepartamentos.FirstOrDefaultAsync(X => X.Id == id);
            if (entidade == null)
            {
                return NotFound();
            }

            return mapper.Map<DepartamentoDTO>(entidade);
        }
    }
}
