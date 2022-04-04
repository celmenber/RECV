using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblAlertasTemprana
    {
        public TblAlertasTemprana()
        {
            TblArchivosCasos = new HashSet<TblArchivosCaso>();
            TblCriterios = new HashSet<TblCriterio>();
        }

        public int Id { get; set; }
        public int IdRemitente { get; set; }
        public string NumeroRadicado { get; set; }
        public DateTime FechaDocumento { get; set; }
        public DateTime? Fecha { get; set; }
        public string Asunto { get; set; }
        public int IdDpto { get; set; }
        public int IdMunicipio { get; set; }
        public int? IdUmg { get; set; }

        public virtual TblDepartamento IdDptoNavigation { get; set; }
        public virtual TblMunicipio IdMunicipioNavigation { get; set; }
        public virtual TblRemitente IdRemitenteNavigation { get; set; }
        public virtual ICollection<TblArchivosCaso> TblArchivosCasos { get; set; }
        public virtual ICollection<TblCriterio> TblCriterios { get; set; }
    }
}
