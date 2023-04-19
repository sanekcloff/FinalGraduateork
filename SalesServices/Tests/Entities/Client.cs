using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Entities
{
    public class Client
    {
        public int Id { get; set; }

        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BonusCard { get; set; } = null!;

        public Passport Passport { get; set; } = null!;
        public MigrationCard MigrationCard { get; set; } = null!;
    }
}
