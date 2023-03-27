using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Entities
{
    public class UserService
    {
        public int ID { get; set; }

        public DateTime DateOfOrder { get; set; }
        public DateTime DateOfCompletion { get; set; }

        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }

        public Service Service { get; set; } = null!;
        public User User { get; set; } = null!;
        public Status Status { get; set; } = null!;
    }
}
