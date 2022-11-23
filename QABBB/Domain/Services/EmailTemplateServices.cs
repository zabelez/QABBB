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
    public class EmailTemplateServices
    {
        private readonly QABBBContext _context;
        private readonly EmailTemplateRepository _emailTemplateRepository;

        public EmailTemplateServices(QABBBContext context) {
            _context = context;
            _emailTemplateRepository = new EmailTemplateRepository(_context);
        }

        public List<EmailTemplate> list() {
            return _emailTemplateRepository.list();
        }

        public EmailTemplate? findById(int id) {
            return _emailTemplateRepository.findById(id);
        }

        public bool add(EmailTemplate emailTemplate) {
            return _emailTemplateRepository.add(emailTemplate) ? true : false;
        }

        public bool edit(EmailTemplate emailTemplate){
            return _emailTemplateRepository.edit(emailTemplate);
        }

        public bool delete(EmailTemplate emailTemplate){
            return _emailTemplateRepository.delete(emailTemplate);
        }
    }
}

