using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Entities
{
    public class ProductCategory
    {
        public int ID { get; set; }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public Product Product { get; set; } = null!;
        public Category Category { get; set; } = null!;
    }
}
