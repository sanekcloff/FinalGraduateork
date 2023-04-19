using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int ID { get; set; }

        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Picture { get; set; } = null!;
        public decimal Cost { get; set; }
        public decimal Discount { get; set; }
        public DateTime DateOfAdd { get; set; }

        public ICollection<UserProduct> UserProducts { get; set; } = null!;
        public ICollection<FavoriteUserProduct> FavoriteUserProducts { get; set; } = null!;
        public ICollection<ProductCategory> ProductCategories { get; set; } = null!;

        [NotMapped]
        public string CorrectPicturePath 
        {
            get => (Picture == string.Empty || Picture == null) 
                ? @"\Resources\Pictures\NonPicture.png" : @$"\Resources\Pictures\{Picture}";
        }
        
        public bool IsDiscount { get => Discount==1 ? false : true; }
        public decimal CorrectCost { get => IsDiscount ? Cost*Discount : Cost; }
        public int CorrectDiscount { get => (int)((1-Discount)*100); }
    }
}
