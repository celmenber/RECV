using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblConductasVulneradora
    {
        public TblConductasVulneradora()
        {
            TblConductasCriterios = new HashSet<TblConductasCriterio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual ICollection<TblConductasCriterio> TblConductasCriterios { get; set; }
    }
}
