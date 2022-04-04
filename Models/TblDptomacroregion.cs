using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblDptomacroregion
    {
        public int Id { get; set; }
        public int? IdDpto { get; set; }
        public int? IdMacroregion { get; set; }

        public virtual TblDepartamento IdDptoNavigation { get; set; }
        public virtual TblMacroregion IdMacroregionNavigation { get; set; }
    }
}
