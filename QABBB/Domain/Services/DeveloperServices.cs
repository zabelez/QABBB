using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QABBB.API.Assemblers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using QABBB.API.Models.Developer;
using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace QABBB.Domain.Services
{
    public class DeveloperServices
    {
        private readonly QABBBContext _context;
        private readonly DeveloperRepository _developerRepository;

        public DeveloperServices(QABBBContext context) {
            _context = context;
            _developerRepository = new DeveloperRepository(_context);
        }

        public List<Developer> list() {
            return _developerRepository.list();
        }

        public Developer? findById(int id) {
            return _developerRepository.findById(id);
        }

        public bool add(Developer developer) {
            return _developerRepository.add(developer) ? true : false;
        }
    }
}

