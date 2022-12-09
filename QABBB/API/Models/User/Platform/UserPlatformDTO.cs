using System;
namespace QABBB.API.Models.User.Platform
{
    public class UserPlatformDTO
    {
        public int IdUserPlatform { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedById {get; set;}
        public string CreatedByName { get; set; }

    }
}