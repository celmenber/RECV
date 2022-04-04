using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblCriterio
    {
        public TblCriterio()
        {
            TblConductasCriterios = new HashSet<TblConductasCriterio>();
        }

        public int Id { get; set; }
        public int IdAt { get; set; }
        public string RecomendacionesAt { get; set; }
        public string RecomendacioneIs { get; set; }
        public string OficioConsumacion { get; set; }
        public string GestionPddh { get; set; }
        public string RespuestaSolicitud { get; set; }
        public string OtrosAsuntos { get; set; }

        public virtual TblAlertasTemprana IdAtNavigation { get; set; }
        public virtual ICollection<TblConductasCriterio> TblConductasCriterios { get; set; }
    }
}
