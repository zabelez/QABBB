using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class LinkRepository
    {
        private readonly QABBBContext _context;

        public LinkRepository(QABBBContext context) {
            _context = context;
        }

        public List<Link> list(){
            return _context.Links.ToList();
        }

        public bool add(Link link) {
            _context.Links.Add(link);
            _context.SaveChanges();
            return true;
        }

        public bool save(Link link){
            _context.Entry(link).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public Link? findById(int id) {
            return _context.Links.FirstOrDefault();
        }

        public bool edit(Link link){
            _context.Entry(link).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public bool delete(Link link){
            _context.Links.Remove(link);
            _context.SaveChanges();
            return true;
        }
    }
}

