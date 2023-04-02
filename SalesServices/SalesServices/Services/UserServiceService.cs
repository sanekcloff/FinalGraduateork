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
    public class UserServiceService
    {
        private ApplicationDbContext _ctx;

        public UserServiceService(ApplicationDbContext ctx) 
        {
            _ctx = ctx;
        }

        public List<UserSvc> GetUserServices()
        {
            return _ctx.UserServices
                .Include(us=>us.Service)
                .Include(us=>us.User)
                    .ThenInclude(u=>u.UserProfile)
                .Include(us => us.User)
                    .ThenInclude(u => u.Role)
                .Include(us=>us.Status)
                .ToList();
        }
        public UserSvc GetUserService(UserSvc userSvc)
        {
            return _ctx.UserServices
                .Include(us => us.Service)
                .Include(us => us.User)
                    .ThenInclude(u => u.UserProfile)
                .Include(us => us.User)
                    .ThenInclude(u => u.Role)
                .Include(us => us.Status)
                .SingleOrDefault(us=>us.Equals(userSvc));
        }
        public void Insert(UserSvc userService)
        {
            _ctx.UserServices.Add(userService);
            _ctx.SaveChanges();
        }
        public void Update(UserSvc userService) 
        { 
            _ctx.UserServices.Update(userService);
            _ctx.SaveChanges();
        }
        public void Delete(UserSvc userService)
        {
            _ctx.UserServices.Remove(userService);
            _ctx.SaveChanges();
        }
    }
}
