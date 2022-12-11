using System;
namespace QABBB.API.Models.User
{
    public class LoginOUTDTO
    {
        public int IdUser { get; set; }
        public string? UserName { get; set; }
        public bool? IsDarkMode { get; set; }
        public string? Token { get; set; }
        public List<String>? Roles { get; set; }
    }
}

