using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblMacroregion
    {
        public TblMacroregion()
        {
            TblDptomacroregions = new HashSet<TblDptomacroregion>();
        }

        public int Id { get; set; }
        public string Nombremacroregion { get; set; }

        public virtual ICollection<TblDptomacroregion> TblDptomacroregions { get; set; }
    }
}
