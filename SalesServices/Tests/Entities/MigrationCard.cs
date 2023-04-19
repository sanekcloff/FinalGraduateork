using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Entities
{
    public class MigrationCard
    {
        public int Id { get; set; }

        public int CardNumber { get; set; }
        public string Where { get; set; } = null!;
        public DateTime StayWith { get; set; }
        public DateTime StayBy { get; set; }
        public string Purpose { get; set; } = null!;

        public Client Client { get; set; } = null!;
    }
}
