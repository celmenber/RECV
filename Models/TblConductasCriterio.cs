using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblConductasCriterio
    {
        public int Id { get; set; }
        public int IdCondutas { get; set; }
        public int IdCriterios { get; set; }

        public virtual TblConductasVulneradora IdCondutasNavigation { get; set; }
        public virtual TblCriterio IdCriteriosNavigation { get; set; }
    }
}
