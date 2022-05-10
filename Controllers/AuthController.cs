using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebApp_AT.Data.Interfaces;
using WebApp_AT.DTOs;
using WebApp_AT.Models;
using WebApp_AT.Services.Interfaces;

namespace WebApp_AT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthController(RECVContext context,  IMapper mapper, IAuthRepository repo, ITokenService tokenService)
        {
            this._mapper = mapper;
            this._repo = repo;
            this._tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioLoginDTO usuarioLoginDTO)
        {
            var usuarioFromRepo = await _repo.Login(usuarioLoginDTO.Usuario.ToLower(), usuarioLoginDTO.Passwordhash);

            if (usuarioFromRepo == null) return Unauthorized();
            //return BadRequest(new
            //{
            //    code = 101
            //});


            var usuario = _mapper.Map<UsuarioListDTO>(usuarioFromRepo);

            var respuesta = new
            {
                status = HttpStatusCode.OK,
                token = _tokenService.CreateToken(usuarioFromRepo),
                usuario,
            };

            return Ok(respuesta);
        }

    }
}
