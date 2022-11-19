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
    public class DeveloperEmployeePositionServices
    {
        private readonly QABBBContext _context;
        private readonly DeveloperEmployeePositionRepository _depRepository;

        public DeveloperEmployeePositionServices(QABBBContext context) {
            _context = context;
            _depRepository = new DeveloperEmployeePositionRepository(_context);
        }

        public List<DeveloperEmployeePosition> list() {
            return _depRepository.list();
        }

        public DeveloperEmployeePosition? findById(int id) {
            return _depRepository.findById(id);
        }

        public bool add(DeveloperEmployeePosition dep) {
            return _depRepository.add(dep) ? true : false;
        }

        public bool edit(DeveloperEmployeePosition dep){
            return _depRepository.edit(dep);
        }
    }
}

