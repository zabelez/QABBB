using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class EmailTemplateRepository
    {
        private readonly QABBBContext _context;

        public EmailTemplateRepository(QABBBContext context) {
            _context = context;
        }

        public List<EmailTemplate> list(){
            return _context.EmailTemplates.ToList();
        }

        public bool add(EmailTemplate emailTemplate)
        {
            _context.EmailTemplates.Add(emailTemplate);
            _context.SaveChanges();
            return true;
        }

        public bool save(EmailTemplate emailTemplate){
            _context.Entry(emailTemplate).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public EmailTemplate? findById(int id) {
            return _context.EmailTemplates
                .Where(u => u.IdEmailTemplate == id)
                .FirstOrDefault();
        }

        public bool edit(EmailTemplate emailTemplate){
            _context.Entry(emailTemplate).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public bool delete(EmailTemplate emailTemplate){
            _context.EmailTemplates.Remove(emailTemplate);
            _context.SaveChanges();
            return true;
        }
    }
}

