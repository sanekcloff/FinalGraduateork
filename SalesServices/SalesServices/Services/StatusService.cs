using SalesServices.Data;
using SalesServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Services
{
    public class StatusService
    {
        private ApplicationDbContext _ctx;

        public StatusService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<Status> GetStatuses()
        {
            return _ctx.Statuses.ToList();
        }
    }
}
