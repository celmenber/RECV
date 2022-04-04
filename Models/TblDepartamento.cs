using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblDepartamento
    {
        public TblDepartamento()
        {
            TblAlertasTempranas = new HashSet<TblAlertasTemprana>();
            TblDptomacroregions = new HashSet<TblDptomacroregion>();
            TblMunicipios = new HashSet<TblMunicipio>();
        }

        public int Id { get; set; }
        public string CodigoDane { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<TblAlertasTemprana> TblAlertasTempranas { get; set; }
        public virtual ICollection<TblDptomacroregion> TblDptomacroregions { get; set; }
        public virtual ICollection<TblMunicipio> TblMunicipios { get; set; }
    }
}
