using System;
using System.Collections.Generic;

namespace MissingBooksScheduler.Models
{
    public partial class UserLogin
    {
        public string UserId { get; set; }
        public string ApplicationUserId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderKey { get; set; }

        public virtual Users ApplicationUser { get; set; }
    }
}
