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
    public class AdminServices
    {
        private readonly QABBBContext _context;
        private readonly AdminRepository _adminRepository;

        public AdminServices(QABBBContext context)
        {
            _context = context;
            _adminRepository = new AdminRepository(_context);
        }

        public bool isAdmin(User user)
        {
            if (_adminRepository.findByIdUser(user.IdPerson) != null)
                return true;

            return false;
        }

        public bool add(Admin admin, int createdBy)
        {
            admin.CreatedAt = DateTime.Now;
            admin.CreatedBy = createdBy;
            return _adminRepository.add(admin);
        }

        public bool add(User user, int createdBy)
        {
            Admin admin = new Admin();
            admin.IdUser = user.IdPerson;
            return add(admin, createdBy);
        }

        public List<Admin> adminList(){
            return _adminRepository.findAll();
        }

        public Admin? findById(int id, string status = "Active")
        {
            if(id == 0)
                return null;

            switch (status)
            {
                case "Active":
                    return _adminRepository.findByIdActive(id);
                case "All":
                    return _adminRepository.findById(id);
                
            }

            return _adminRepository.findByIdActive(id);
        }

        public Admin? findByIdUser(int id)
        {
            return _adminRepository.findByIdUser(id);
        }

        public bool inactivate(Admin admin, int removedBy){
            admin.RemovedAt = DateTime.Now;
            admin.RemovedBy = removedBy;
            return _adminRepository.save(admin);
        }

    }
}

