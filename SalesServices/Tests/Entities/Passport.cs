using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Entities
{
    public class Passport
    {
        public int Id { get; set; }

        public int Series { get; set; }
        public int Number { get; set; }
        public string DocumentType { get; set; } = null!;
        public DateTime Issued { get; set; }
        public string Address { get; set; } = null!;
        public string Country { get; set; } = null!;

        public Client Client { get; set; } = null!;
    }
}
