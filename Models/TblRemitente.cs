using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblRemitente
    {
        public TblRemitente()
        {
            TblAlertasTempranas = new HashSet<TblAlertasTemprana>();
        }

        public int Id { get; set; }
        public string NombreRemitente { get; set; }
        public string Email { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual ICollection<TblAlertasTemprana> TblAlertasTempranas { get; set; }
    }
}
