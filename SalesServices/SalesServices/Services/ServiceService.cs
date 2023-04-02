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

        public Service GetService(Service service)
        {
            return _ctx.Services.SingleOrDefault(s=>s.Equals(service));
        }

        public void Insert(Service service)
        {
            _ctx.Services.Add(service);
            _ctx.SaveChanges();
        }

        public void Update(Service service)
        {
            _ctx.Services.Update(service);
            _ctx.SaveChanges();
        }
        public void Delete(Service service)
        {
            _ctx.Services.Remove(service);
            _ctx.SaveChanges();
        }
    }
}
