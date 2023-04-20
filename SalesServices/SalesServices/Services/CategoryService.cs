using SalesServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Services
{
    public class CategoryService
    {
        private ApplicationDbContext _ctx;
        public CategoryService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }    
    }
}
