using System;
using System.Collections.Generic;

namespace MissingBooksScheduler.Models
{
    public partial class UserClaims
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string UserId { get; set; }

        public virtual Users ApplicationUser { get; set; }
    }
}
