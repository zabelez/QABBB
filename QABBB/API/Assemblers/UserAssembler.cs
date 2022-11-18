using System;
using QABBB.API.Models.User;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class UserAssembler
    {

        public UserDTO toUserDTO(User user) {

            UserDTO newUser = new UserDTO();
            newUser.IdPerson = user.IdPerson;
            newUser.UserName = user.UserName;
            newUser.PersonName = user.IdPersonNavigation.PersonName;
            newUser.IsDarkMode = user.IsDarkMode;
            newUser.Status = user.Status;

            return newUser;
        }

        public User toUser(User user, EditUserDTO editUserDTO){
            user.UserName = editUserDTO.PersonName;
            user.IsDarkMode = editUserDTO.IsDarkMode;
            user.Status = editUserDTO.Status;
            user.IdPersonNavigation.PersonName = editUserDTO.PersonName;
            user.IdPersonNavigation.Email = editUserDTO.Email;
            return user;
        }

        public List<UserDTO> toUserDTO(IEnumerable<User> users) {

            List<UserDTO> newUsers = new List<UserDTO>();

            foreach (User user in users) {
                newUsers.Add(this.toUserDTO(user));
            }

            return newUsers;
        }

        public LoginOUTDTO toLoginOUTDTO(User user, string token) {

            LoginOUTDTO newUser = new LoginOUTDTO();
            newUser.IdUser = user.IdPerson;
            newUser.UserName = user.UserName;
            newUser.IsDarkMode = user.IsDarkMode;
            newUser.Token = token;

            return newUser;
        }

        public User toUser(NewUserDTO user) {

            User newUser = new User();
            newUser.UserName = user.UserName;
            newUser.IdPersonNavigation = new Person();
            newUser.IsDarkMode = user.IsDarkMode;
            newUser.IdPersonNavigation.PersonName = user.PersonName;
            newUser.IdPersonNavigation.Email = user.Email;

            return newUser;
        }
    }
}

