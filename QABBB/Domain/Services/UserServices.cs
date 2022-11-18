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

        public UserServices(QABBBContext context) {
            _context = context;
            _userRepository = new UserRepository(_context);
        }

        public User? login(string userName, string password){
            return _userRepository.Login(userName, password);
        }

        public List<User> userList() {
            return _userRepository.userList();
        }

        public User? findById(int id) {
            return _userRepository.findById(id);
        }

        public bool add(User user) {
            Random r = new Random();
            user.Password = r.Next(100000, 1000000).ToString();
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

            User? username = _userRepository.findByUserName(newUserDTO.UserName);
            if (username != null)
                errors.Add("Username already exists.");

            User? email = _userRepository.findByEmail(newUserDTO.Email);
            if (email != null)
                errors.Add("Email already exists.");

            return errors;
        }

        public bool inactivate(User user){
            user.Status = "Inactivate";
            return _userRepository.save(user);
        }
    }
}

