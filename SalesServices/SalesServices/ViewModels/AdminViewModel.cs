using SalesServices.Data;
using SalesServices.Entities;
using SalesServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.ViewModels
{
    public class AdminViewModel:ViewModelBase
    {
        private List<Product> _products;
        public List<Product> Products { get => _products; set => Set(ref _products, value, nameof(Products)); }

        public ProductService ProductService { get; }
        public AdminViewModel(ApplicationDbContext ctx)
        {
            ProductService = new ProductService(ctx);

            Products=new List<Product>(ProductService.GetProducts());
        }
    }
}
