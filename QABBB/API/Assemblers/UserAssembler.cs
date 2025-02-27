﻿using System;
using QABBB.API.Models.Company.Employee;
using QABBB.API.Models.User;
using QABBB.API.Models.User.Platform;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class UserAssembler
    {
        
        UserPlatformAssembler userPlatformAssembler = new UserPlatformAssembler();
        CompanyEmployeeAssembler companyEmployeeAssembler = new CompanyEmployeeAssembler();

        public UserDTO toUserDTO(User user) {

            UserDTO newUser = new UserDTO();
            newUser.IdPerson = user.IdPerson;
            newUser.IsDarkMode = user.IsDarkMode;
            newUser.Status = user.Status;
            newUser.PersonName = user.IdPersonNavigation.PersonName;
            newUser.Email = user.IdPersonNavigation.Email;

            return newUser;
        }

        public UserPlatformsEmployeeDTO toUserAndPlatformsDTO(User user) {

            UserPlatformsEmployeeDTO newUser = new UserPlatformsEmployeeDTO();
            newUser.IdPerson = user.IdPerson;
            newUser.IsDarkMode = user.IsDarkMode;
            newUser.Status = user.Status;
            newUser.PersonName = user.IdPersonNavigation.PersonName;
            newUser.Email = user.IdPersonNavigation.Email;

            newUser.Platforms = userPlatformAssembler.toUserPlatformDTO(user.UserPlatformIdUserNavigations);
            newUser.Employers = companyEmployeeAssembler.toCompanyEmployeeForUserDTO(user.CompanyEmployeeIdPersonNavigations);

            return newUser;
        }

        public User toUser(User user, EditUserDTO editUserDTO, int idPerson){
            user.IsDarkMode = editUserDTO.IsDarkMode;
            user.Status = editUserDTO.Status;
            user.IdPersonNavigation.PersonName = editUserDTO.PersonName;
            user.IdPersonNavigation.Email = editUserDTO.Email;

            foreach (CompanyEmployeeInputForPutUser companyEmployee in editUserDTO.employers)
            {
                if (companyEmployee.IdCompanyEmployee == null)
                    user.CompanyEmployeeIdPersonNavigations.Add(companyEmployeeAssembler.toCompanyEmployee(user, companyEmployee, idPerson));
            }

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
            newUser.IsDarkMode = user.IsDarkMode;
            newUser.Token = token;
            newUser.UserName = user.IdPersonNavigation.PersonName;

            return newUser;
        }

        public User toUser(NewUserDTO user, int idPerson) {

            User newUser = new User();
            newUser.IdPersonNavigation = new Person();
            newUser.IsDarkMode = user.IsDarkMode;
            newUser.IdPersonNavigation.PersonName = user.PersonName!;
            newUser.IdPersonNavigation.Email = user.Email;

            foreach (CompanyEmployeeInputForPostUser employer in user.employers)
            {
                newUser.CompanyEmployeeIdPersonNavigations.Add(companyEmployeeAssembler.toCompanyEmployee(newUser, employer, idPerson));
            }

            return newUser;
        }
    }
}

