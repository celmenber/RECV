using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_AT.DTOs;
using WebApp_AT.Models;

namespace WebApp_AT.Helpers
{
    public class AutoMapperAT: Profile
    {
        public AutoMapperAT()
        {

            CreateMap<AlertasTCreacionDTO, TblAlertasTemprana>();
            CreateMap<ConductasCriterioDTO, TblConductasCriterio>().ReverseMap();
            CreateMap<TblAlertasTemprana, AlertasTempranaDTO>().ReverseMap();
            CreateMap<TblConductasVulneradora, ConductasvulneradoraDTO>().ReverseMap();
            CreateMap<TblCriterio, CriterioDTO>().ReverseMap();
            CreateMap<TblDepartamento, DepartamentoDTO>().ReverseMap();
            CreateMap<TblMunicipio, MunicipioDTO>().ReverseMap();
            CreateMap<TblRemitente, RemitenteDTO>().ReverseMap();
            CreateMap<TblUnidadMinimaGeo, UnidadminimageoDTO>().ReverseMap();
            CreateMap<TblMacroregion, MacroregionDTO>().ReverseMap();
            CreateMap<TblArchivosCaso, ArchivoscasoDTO>().ReverseMap();

            CreateMap<ArchivoscreacionDTO, TblArchivosCaso>()
                .ForMember(x => x.RutaArchivo, options => options.Ignore()).ReverseMap();
            CreateMap<ArchivoscreacionDTO, TblArchivosCaso>();

        }
    }
}
