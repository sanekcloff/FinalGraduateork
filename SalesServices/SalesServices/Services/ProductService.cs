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
    public class ProductService
    {
        private ApplicationDbContext _ctx;
        public ProductService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<Product> GetProducts()
        {
            return _ctx.Products.Include(p=>p.ProductCategory).ToList();
        }
    }
}
