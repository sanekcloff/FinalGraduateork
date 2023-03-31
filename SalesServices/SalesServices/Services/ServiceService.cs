using SalesServices.Data;
using SalesServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Services
{
    public class ServiceService
    {
        private ApplicationDbContext _ctx;

        public ServiceService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<Service> GetServices()
        {
            return _ctx.Services.ToList();
        }
    }
}
