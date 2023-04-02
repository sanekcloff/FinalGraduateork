using SalesServices.Entities;
using SalesServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesServices.ViewModels.EntitiesViewModels
{
    public class ProductPageViewModel:ViewModelBase
    {
        private bool isNew=false;
        public ProductService Service { get; }
        public ProductPageViewModel(Product product, ProductService entityService)
        {
            if (entityService.GetProduct(product)==null)
            {
                isNew = true;
            }
            Service= entityService;
        }
    }
}
