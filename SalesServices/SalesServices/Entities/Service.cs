using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Entities
{
    public class Service
    {
        public Service()
        {
            UserServices = new HashSet<UserSvc>();
        }

        public int ID { get; set; }

        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal CostPerHour { get; set; }
        public DateTime DateOfAdd { get; set; }

        public ICollection<UserSvc> UserServices { get; set; } = null!;
    }
}
