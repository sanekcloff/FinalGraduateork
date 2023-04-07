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
    public class UserProductService
    {
        private ApplicationDbContext _ctx;

        public UserProductService(ApplicationDbContext ctx)
        {
            _ctx= ctx;
        }
        public ICollection<UserProduct> GetUserProducts()
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

        public UserProduct GetUserProduct(UserProduct userProduct)
        {
            return _ctx.UserProducts
                .Include(up => up.Product)
                    .ThenInclude(p => p.ProductCategory)
                .Include(up => up.User)
                    .ThenInclude(u => u.Role)
                .Include(up => up.User)
                    .ThenInclude(u => u.UserProfile)
                .Include(up => up.Status)
                .SingleOrDefault(up => up.Equals(userProduct));
        }

        public void Insert(UserProduct userProduct)
        {
            _ctx.UserProducts.Add(userProduct);
            _ctx.SaveChanges();
        }
        public void Update(UserProduct userProduct)
        {
            _ctx.UserProducts.Update(userProduct);
            _ctx.SaveChanges();
        }
        public void Delete(UserProduct userProduct)
        {
            _ctx.UserProducts.Remove(userProduct);
            _ctx.SaveChanges();
        }
    }
}
