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
            CompanyEmployeeCreatedByNavigations = new HashSet<CompanyEmployee>();
            CompanyEmployeeIdPersonNavigations = new HashSet<CompanyEmployee>();
            CompanyEmployeeRemovedByNavigations = new HashSet<CompanyEmployee>();
            Logs = new HashSet<Log>();
            UserPlatformCreatedByNavigations = new HashSet<UserPlatform>();
            UserPlatformIdUserNavigations = new HashSet<UserPlatform>();
            UserPlatformRemovedByNavigations = new HashSet<UserPlatform>();
        }

        public int IdPerson { get; set; }
        public string Password { get; set; } = null!;
        public bool IsPasswordResetRequired { get; set; }
        public bool IsDarkMode { get; set; }
        public string Status { get; set; } = null!;

        public virtual Person IdPersonNavigation { get; set; } = null!;
        public virtual ICollection<Admin> AdminCreatedByNavigations { get; set; }
        public virtual ICollection<Admin> AdminIdUserNavigations { get; set; }
        public virtual ICollection<Admin> AdminRemovedByNavigations { get; set; }
        public virtual ICollection<CompanyEmployee> CompanyEmployeeCreatedByNavigations { get; set; }
        public virtual ICollection<CompanyEmployee> CompanyEmployeeIdPersonNavigations { get; set; }
        public virtual ICollection<CompanyEmployee> CompanyEmployeeRemovedByNavigations { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<UserPlatform> UserPlatformCreatedByNavigations { get; set; }
        public virtual ICollection<UserPlatform> UserPlatformIdUserNavigations { get; set; }
        public virtual ICollection<UserPlatform> UserPlatformRemovedByNavigations { get; set; }
    }
}
