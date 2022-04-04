using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_AT.DTOs
{
    public class MacroregionDTO
    {
        [Key]
        public int Id { get; set; }
        public string Nombremacroregion { get; set; }
    }
}
