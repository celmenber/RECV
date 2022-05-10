using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblNetUserRole
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual TblNetRole Role { get; set; }
        public virtual TblNetUser User { get; set; }
    }
}
