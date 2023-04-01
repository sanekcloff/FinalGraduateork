using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesServices.Entities
{
    public class UserProduct
    {
        public int ID { get; set; }

        public int Quantity { get;set; }
        public DateTime DateOfOrder { get;set; }
        public DateTime? DateOfCompletion { get; set; }

        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }

        public Product Product { get; set; } = null!;
        public User User { get; set; } = null!;
        public Status Status { get; set; } = null!;

        [NotMapped]
        public decimal FullCost { get => Product.Cost*Quantity; }
    }
}