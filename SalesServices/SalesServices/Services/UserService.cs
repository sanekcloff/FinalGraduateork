using Microsoft.EntityFrameworkCore;
using SalesServices.Data;
using SalesServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Services
{
    public class UserService
    {
        private ApplicationDbContext _ctx;

        public UserService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public User GetUser(string login, string password)
        {
            return _ctx.Users.Include(u => u.UserProfile).Include(u=>u.Role).SingleOrDefault(u => u.Login == login && u.Password == password);
        }
        public ICollection<User> GetUsers()
        {
            return _ctx.Users.Include(u => u.UserProfile).Include(u=>u.Role).ToList();
        }
    }
}
