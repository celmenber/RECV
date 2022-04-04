using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblMunicipio
    {
        public TblMunicipio()
        {
            TblAlertasTempranas = new HashSet<TblAlertasTemprana>();
            TblUnidadMinimaGeos = new HashSet<TblUnidadMinimaGeo>();
        }

        public int Id { get; set; }
        public int? IdDpto { get; set; }
        public string CodigoDane { get; set; }
        public string Nombre { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public virtual TblDepartamento IdDptoNavigation { get; set; }
        public virtual ICollection<TblAlertasTemprana> TblAlertasTempranas { get; set; }
        public virtual ICollection<TblUnidadMinimaGeo> TblUnidadMinimaGeos { get; set; }
    }
}
