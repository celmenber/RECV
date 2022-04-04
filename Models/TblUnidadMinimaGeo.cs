using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblUnidadMinimaGeo
    {
        public int Id { get; set; }
        public int IdMunicipio { get; set; }
        public string Nombre { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public virtual TblMunicipio IdMunicipioNavigation { get; set; }
    }
}
