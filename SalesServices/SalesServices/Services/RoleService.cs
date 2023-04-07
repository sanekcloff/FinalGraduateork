using SalesServices.Data;
using SalesServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Services
{
    public class RoleService
    {
        private ApplicationDbContext _ctx;

        public RoleService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<Role> GetRoles()
        {
            return _ctx.Roles.ToList();
        }
    }
}
