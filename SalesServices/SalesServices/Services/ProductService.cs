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
            return _ctx.Products.Include(p=>p.ProductCategories).ToList();
        }
        public Product GetProduct(Product product)
        {
            return _ctx.Products.Include(p=>p.ProductCategories).SingleOrDefault(p=>p.Equals(product));
        }
        public void Insert(Product product) 
        { 
            _ctx.Products.Add(product);
            _ctx.SaveChanges();
        }
        public void Update(Product product)
        {
            _ctx.Products.Update(product);
            _ctx.SaveChanges();
        }
        public void Delete(Product product)
        {
            _ctx.Products.Remove(product);
            _ctx.SaveChanges();
        }
    }
}
