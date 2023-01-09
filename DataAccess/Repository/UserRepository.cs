using Common.Model;
using DataAccess.dbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private NegoSudDBContext _context;

        public UserRepository(NegoSudDBContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public User Get(int id)
        {
            return _context.Users.First(usr => usr.Id == id);
        }

        public bool Login(string email, string pass)
        {
            return _context.Users.First(usr => usr.Email == email).Password == pass;
        }

        public User Get(string email)
        {
            return _context.Users.First(usr => usr.Email == email);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
