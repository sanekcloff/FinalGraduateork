using SalesServices.Data;
using SalesServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Services
{
    public class ProductCategoryService
    {
        private ApplicationDbContext _ctx;

        public ProductCategoryService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<ProductCategory> GetProductCategories()
        {
            return _ctx.ProductCategories.ToList();
        }
    }
}
