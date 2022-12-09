using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QABBB.API.Assemblers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using QABBB.API.Models.Company;
using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace QABBB.Domain.Services
{
    public class CompanyServices
    {
        private readonly QABBBContext _context;
        private readonly CompanyRepository _ceRepository;

        public CompanyServices(QABBBContext context)
        {
            _context = context;
            _ceRepository = new CompanyRepository(_context);
        }

        public List<Company> list() {
            return _ceRepository.list();
        }

        public Company? findById(int id) {
            return _ceRepository.findById(id);
        }

        public bool add(Company company) {
            return _ceRepository.add(company) ? true : false;
        }

        public bool edit(Company company){
            return _ceRepository.edit(company);
        }
    }
}

