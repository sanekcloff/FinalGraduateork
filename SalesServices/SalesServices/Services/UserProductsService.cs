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
    public class UserProductsService
    {
        private ApplicationDbContext _ctx;

        public UserProductsService(ApplicationDbContext ctx)
        {
            _ctx= ctx;
        }

        public List<UserProduct> GetUserProducts()
        {
            return _ctx.UserProducts
                .Include(up=>up.Product)
                    .ThenInclude(p=>p.ProductCategory)
                .Include(up=>up.User)
                    .ThenInclude(u=>u!.Role)
                .Include(up => up.User)
                    .ThenInclude(u=>u.UserProfile)
                .Include(up=>up.Status)
                .ToList();
        }
    }
}
