﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_AT.Data.Interfaces;
using WebApp_AT.DTOs;
using WebApp_AT.Models;

namespace WebApp_AT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IMapper _mapper;
        private readonly RECVContext _context;
        public UsuarioController(RECVContext context, IMapper mapper, IAuthRepository repo)
        {
            this._mapper = mapper;
            this._repo = repo;
            this._context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<UsuarioListDTO>>> Get()
        {
            var entidad = await _context.TblUsuarios.ToListAsync();
            return _mapper.Map<List<UsuarioListDTO>>(entidad);

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuarioListDTO>> UsuarioGet(int id)
        {

            var entidad = await _context.TblUsuarios.FirstOrDefaultAsync(X => X.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }

            return _mapper.Map<UsuarioListDTO>(entidad);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UsuarioRegisterDTO usuarioRegisterDTO)
        {

            usuarioRegisterDTO.Usuario = usuarioRegisterDTO.Usuario.ToLower();

            if (await _repo.UserExists(usuarioRegisterDTO.Usuario))
                return BadRequest(new
                {
                    Msg = "Usuario con ese correo ya existe",
                    code= 101
                });


            var usuarioToCreate = _mapper.Map<TblUsuario>(usuarioRegisterDTO);

            var UsuarioCreated = await _repo.Register(usuarioToCreate, usuarioRegisterDTO.Passwordhash);

            var UsuarioReturn = _mapper.Map<UsuarioListDTO>(UsuarioCreated);

            return Ok(UsuarioReturn);
        }
    }
}
