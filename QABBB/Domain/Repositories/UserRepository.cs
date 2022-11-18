using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class UserRepository
    {
        private readonly QABBBContext _context;

        public UserRepository(QABBBContext context) {
            _context = context;
        }

        public User? findByUserNameAndPassword(string userName, string password) {

            return _context.Users
                .Include(u => u.IdPersonNavigation)
                .Where(u => u.UserName == userName && u.Password == password && u.Status == "Active")
                .FirstOrDefault();
        }
        public List<User> userList(){
            return _context.Users
                .Include(u => u.IdPersonNavigation)
                .OrderBy(u => u.IdPersonNavigation.PersonName)
                .ToList();
        }

        public bool add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool save(User user){
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public User? findById(int id) {
            return _context.Users
                .Include(u => u.IdPersonNavigation)
                .Where(u => u.IdPerson == id)
                .FirstOrDefault();
        }

        public User? findByUserName(string userName) {
            return _context.Users
                .Include(u => u.IdPersonNavigation)
                .Where(u => u.UserName == userName)
                .FirstOrDefault();
        }

        public User? findByEmail(string email) {
            return _context.Users
                .Include(u => u.IdPersonNavigation)
                .Where(u => u.IdPersonNavigation.Email == email)
                .FirstOrDefault();
        }
    }
}

