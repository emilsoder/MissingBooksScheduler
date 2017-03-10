using System;
using System.Collections.Generic;

namespace MissingBooksScheduler.Models
{
    public partial class RoleClaim
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string IdentityRoleStringId { get; set; }
        public string RoleId { get; set; }

        public virtual Roles IdentityRoleString { get; set; }
    }
}
