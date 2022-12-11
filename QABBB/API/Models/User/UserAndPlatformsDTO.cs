using System;
using QABBB.API.Models.User.Platform;
using QABBB.Models;

namespace QABBB.API.Models.User
{
    public class UserAndPlatformsDTO
    {
        public int IdPerson { get; set; }

        public string? PersonName { get; set; }

        public string? Email { get; set; }

        public bool? IsDarkMode { get; set; }

        public string? Status {get; set;}

        public List<String>? Roles { get; set; }

        public List<UserPlatformDTO>? Platforms {get; set;}

    }
}

