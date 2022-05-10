using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp_AT.Models
{
    public partial class TblNetUser
    {
        public TblNetUser()
        {
            TblNetUserLogins = new HashSet<TblNetUserLogin>();
            TblNetUserRoles = new HashSet<TblNetUserRole>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<TblNetUserLogin> TblNetUserLogins { get; set; }
        public virtual ICollection<TblNetUserRole> TblNetUserRoles { get; set; }
    }
}
