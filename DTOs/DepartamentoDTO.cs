﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_AT.DTOs
{
    public class DepartamentoDTO
    {
        [Key]
        public int Id { get; set; }
        public string CodigoDane { get; set; }
        public string Nombre { get; set; }
    }
}
