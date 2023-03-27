using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Entities
{
    public class Status
    {
        public Status()
        {
            UserProducts = new HashSet<UserProduct>();
        }

        public int ID { get; set; }

        public string Title { get; set; } = null!;

        public ICollection<UserProduct> UserProducts { get; set; }
    }
}
