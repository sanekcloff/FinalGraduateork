using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Entities
{
    public class Role
    {
        public Role()
        {
            Users=new HashSet<User>();
        }

        public int ID { get; set; }

        public string Ttitle { get; set; } = null!;

        public ICollection<User> Users { get; set; }
    }
}
