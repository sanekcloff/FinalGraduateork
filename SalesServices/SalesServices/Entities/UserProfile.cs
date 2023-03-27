using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Entities
{
    public class UserProfile
    {
        public int ID { get; set; }

        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DateOfRegister { get; set; }
        public int NumberOfPurchases { get; set; }
        public int NumberOfServices { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
