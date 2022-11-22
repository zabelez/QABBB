using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QABBB.API.Assemblers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace QABBB.Domain.Services
{
    public class DeveloperEmployeeServices
    {
        private readonly QABBBContext _context;
        private readonly DeveloperEmployeeRepository _developerEmployeeRepository;

        public DeveloperEmployeeServices(QABBBContext context) {
            _context = context;
            _developerEmployeeRepository = new DeveloperEmployeeRepository(_context);
        }

        public List<DeveloperEmployee> list() {
            return _developerEmployeeRepository.list();
        }

        public DeveloperEmployee? findById(int id) {
            return _developerEmployeeRepository.findById(id);
        }

        public bool add(DeveloperEmployee developerEmployee) {
            return _developerEmployeeRepository.add(developerEmployee) ? true : false;
        }

        public bool edit(DeveloperEmployee developerEmployee){
            return _developerEmployeeRepository.edit(developerEmployee);
        }
    }
}

