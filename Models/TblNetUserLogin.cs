using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblNetUserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        public virtual TblNetUser User { get; set; }
    }
}
