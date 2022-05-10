using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblUsuario
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public string Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Passwordhash { get; set; }
        public string Passwordsalt { get; set; }
        public bool? Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
