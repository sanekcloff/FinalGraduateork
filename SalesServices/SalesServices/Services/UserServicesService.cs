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
    public class UserServicesService
    {
        private ApplicationDbContext _ctx;

        public UserServicesService(ApplicationDbContext ctx) 
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
    }
}
