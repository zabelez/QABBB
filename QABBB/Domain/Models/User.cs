using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class User
    {
        public User()
        {
            AdminCreatedByNavigations = new HashSet<Admin>();
            AdminIdUserNavigations = new HashSet<Admin>();
            AdminRemovedByNavigations = new HashSet<Admin>();
            DeveloperEmployees = new HashSet<DeveloperEmployee>();
            Logs = new HashSet<Log>();
            PublisherEmployees = new HashSet<PublisherEmployee>();
            UserPlatforms = new HashSet<UserPlatform>();
        }

        public int IdPerson { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsPasswordResetRequired { get; set; }
        public bool IsDarkMode { get; set; }
        public string Status { get; set; } = null!;

        public virtual Person IdPersonNavigation { get; set; } = null!;
        public virtual ICollection<Admin> AdminCreatedByNavigations { get; set; }
        public virtual ICollection<Admin> AdminIdUserNavigations { get; set; }
        public virtual ICollection<Admin> AdminRemovedByNavigations { get; set; }
        public virtual ICollection<DeveloperEmployee> DeveloperEmployees { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<PublisherEmployee> PublisherEmployees { get; set; }
        public virtual ICollection<UserPlatform> UserPlatforms { get; set; }
    }
}
