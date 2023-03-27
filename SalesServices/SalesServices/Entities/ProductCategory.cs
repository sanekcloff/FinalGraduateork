using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Entities
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            Products= new HashSet<Product>();
        }
        public int ID { get; set; }

        public string Title { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = null!;
    }
}
