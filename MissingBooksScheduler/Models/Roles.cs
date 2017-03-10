using System;
using System.Collections.Generic;

namespace MissingBooksScheduler.Models
{
    public partial class Roles
    {
        public Roles()
        {
            RoleClaim = new HashSet<RoleClaim>();
            UserRoles = new HashSet<UserRoles>();
        }

        public string Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public virtual ICollection<RoleClaim> RoleClaim { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
