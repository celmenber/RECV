using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_AT.DTOs
{
    public class ConductasCriterioDTO
    {
        [Key]
        public int Id { get; set; }
        public int IdCondutas { get; set; }
        public int IdCriterios { get; set; }
    }
}
