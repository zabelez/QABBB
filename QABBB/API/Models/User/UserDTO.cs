using System;
namespace QABBB.API.Models.User
{
    public class UserDTO
    {
        public UserDTO()
        {
        }

        public UserDTO(int idPerson, string userName, bool isDarkMode, bool isAdmin) {
            IdPerson = idPerson;
            UserName = userName;
            IsDarkMode = isDarkMode;
        }

        public int IdPerson { get; set; }

        public string UserName { get; set; }

        public string PersonName { get; set; }

        public bool? IsDarkMode { get; set; }

        public string Status {get; set;}

    }
}

