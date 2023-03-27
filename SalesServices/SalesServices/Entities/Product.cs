using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Entities
{
    public class Product
    {
        public Product()
        {
            UserProducts = new HashSet<UserProduct>();
            FavoriteUserProducts= new HashSet<FavoriteUserProduct>();
        }

        public int ID { get; set; }

        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public decimal Cost { get; set; }
        public int CountInStock { get; set; }
        public decimal Discount { get; set; }
        public DateTime DateOfAdd { get; set; }

        public int ProductCategoryId { get; set; }

        public ProductCategory ProductCategory { get; set; } = null!;

        public ICollection<UserProduct> UserProducts { get; set; } = null!;
        public ICollection<FavoriteUserProduct> FavoriteUserProducts { get; set; } = null!;
    }
}
