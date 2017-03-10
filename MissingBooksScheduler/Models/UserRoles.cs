using System;
using System.Collections.Generic;

namespace MissingBooksScheduler.Models
{
    public partial class UserRoles
    {
        public string RoleId { get; set; }
        public string ApplicationUserId { get; set; }
        public string IdentityRoleStringId { get; set; }
        public string UserId { get; set; }

        public virtual Users ApplicationUser { get; set; }
        public virtual Roles IdentityRoleString { get; set; }
    }
}
