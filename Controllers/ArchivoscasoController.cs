using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp_AT.DTOs;
using WebApp_AT.Models;
using WebApp_AT.Services;

namespace WebApp_AT.Controllers
{
    [ApiController]
    [Route("api/archivos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ArchivoscasoController : ControllerBase
    {
        private readonly RECVContext context;

        private readonly IMapper mapper;

        private readonly IAlmacenadorArchivo almacenadorArchivo;

        private readonly string contenedor = "documentosRadicado";

        public ArchivoscasoController(RECVContext context,
                                      IMapper mapper, 
                                      IAlmacenadorArchivo almacenadorArchivo)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivo = almacenadorArchivo;
        }



        [HttpGet]
        public async Task<ActionResult<List<ArchivoscasoDTO>>> Get()
        {
            var entidades = await context.TblArchivosCasos.ToListAsync();
            return mapper.Map<List<ArchivoscasoDTO>>(entidades);

        }

        [HttpGet("{id:int}", Name = "ObtenerArchivos")]
        public async Task<ActionResult<ArchivoscasoDTO>> Get(int id)
        {

            var entidade = await context.TblArchivosCasos.FirstOrDefaultAsync(X => X.Id == id);
            if (entidade == null)
            {
                return NotFound();
            }

            return mapper.Map<ArchivoscasoDTO>(entidade);
        }

        [HttpGet("obtenerarchivosat/{idCaso}", Name = "obtenerarchivosat")]
        public async Task<ActionResult<List<ArchivoscasoDTO>>> GetArchivosat(int idCaso)
        {

            var entidade = await context.TblArchivosCasos.Where(X => X.IdCasos == idCaso)
                                                     .OrderBy(X => X.IdCasos)
                                                     .ToListAsync();
            if (entidade == null)
            {
                return NotFound();
            }

            return mapper.Map<List<ArchivoscasoDTO>>(entidade);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ArchivospathDTO archivoscreacionDTO)
        {
            var entidad = mapper.Map<TblArchivosCaso>(archivoscreacionDTO);

            var CANTARCH = archivoscreacionDTO.RutaArchivo.Length;

            if (archivoscreacionDTO.RutaArchivo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await archivoscreacionDTO.RutaArchivo.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(archivoscreacionDTO.RutaArchivo.FileName);

                    entidad.RutaArchivo = await almacenadorArchivo.GuardarArchivo(contenido, extension, contenedor, archivoscreacionDTO.RutaArchivo.ContentType);
                    entidad.NombreArchivo = archivoscreacionDTO.RutaArchivo.FileName;
                    entidad.TipoArchivo = archivoscreacionDTO.RutaArchivo.ContentType;
                }
            }

           // Convert.ToString(entidad.RutaArchivo);
            entidad.Fecha = DateTime.Now;
            context.Add(entidad);
            await context.SaveChangesAsync();

            var Archivo_DTO = mapper.Map<ArchivoscasoDTO>(entidad);
            return new CreatedAtRouteResult("ObtenerArchivos", new { id = Archivo_DTO.Id }, Archivo_DTO);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ArchivoscasoDTO archivoscasoDTO)
        {
            var entidad = mapper.Map<TblArchivosCaso>(archivoscasoDTO);

            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();

            var Archivo_DTO = mapper.Map<ArchivoscasoDTO>(entidad);

            return new CreatedAtRouteResult("ObtenerArchivos", new { id = Archivo_DTO.Id }, Archivo_DTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ArchivoscasoDTO>> Delete(int id)
        {
            var existe = await context.TblCriterios.AnyAsync(X => X.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new TblArchivosCaso() { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}
