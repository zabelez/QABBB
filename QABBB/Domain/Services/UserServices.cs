using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QABBB.API.Assemblers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using QABBB.API.Models.User;
using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace QABBB.Domain.Services
{
    public class UserServices
    {
        private readonly QABBBContext _context;
        private readonly UserRepository _userRepository;
        private PasswordServices passwordServices = new PasswordServices();

        public UserServices(QABBBContext context) {
            _context = context;
            _userRepository = new UserRepository(_context);
        }

        public User? login(string userName, string password){

            String hashPassword = passwordServices.HashPasword(password);

            return _userRepository.findByUserNameAndPassword(userName, hashPassword);
        }

        public List<User> userList() {
            return _userRepository.userList();
        }

        public User? findById(int id) {
            return _userRepository.findById(id);
        }

        public bool add(User user) {
            Random r = new Random();
            user.Password = passwordServices.HashPasword(r.Next(100000, 1000000).ToString());
            user.Status = "Active";
            return _userRepository.add(user) ? true : false;
        }

        public bool addCustomPassword(User user, string password) {
            user.Password = passwordServices.HashPasword(password);
            user.Status = "Active";
            return _userRepository.add(user) ? true : false;
        }

        public bool save(User user)
        {
            return _userRepository.save(user);
        }

        public bool resetPassword(User user, string newPassword) {
            user.Password = newPassword;
            user.IsPasswordResetRequired = false;
            return _userRepository.save(user);
        }

        public List<string> newUserValidation(NewUserDTO newUserDTO){
            List<string> errors = new List<string>();

            User? email = _userRepository.findByEmail(newUserDTO.Email!);
            if (email != null)
                errors.Add("Email already exists.");

            return errors;
        }

        public bool inactivate(User user){
            user.Status = "Inactive";
            return _userRepository.save(user);
        }

        public bool edit(User user){
            return _userRepository.edit(user);
        }
    }
}

