using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_AT.DTOs
{
    public class CriterioDTO
    {
        [Key]
        public int Id { get; set; }
        public int IdAt { get; set; }
        public string RecomendacionesAt { get; set; }
        public string RecomendacioneIs { get; set; }
        public string OficioConsumacion { get; set; }
        public string GestionPddh { get; set; }
        public string RespuestaSolicitud { get; set; }
        public string OtrosAsuntos { get; set; }
    }
}
