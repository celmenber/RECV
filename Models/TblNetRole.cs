using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblNetRole
    {
        public TblNetRole()
        {
            TblNetUserRoles = new HashSet<TblNetUserRole>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<TblNetUserRole> TblNetUserRoles { get; set; }
    }
}
