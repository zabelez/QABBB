using System;
namespace QABBB.API.Models.User
{
    public class UserDTO
    {
        public int IdUser { get; set; }

        public string UserName { get; set; }

        public bool? IsDarkMode { get; set; }

        public bool IsAdmin { get; set; }

    }
}

