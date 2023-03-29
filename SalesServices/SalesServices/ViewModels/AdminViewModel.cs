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
        #region Lists
        private List<Product> _products;
        private List<ProductCategory> _productCategories;
        private List<Service> _services;
        private List<User> _user;
        private List<UserProduct> _userProducts;
        private List<UserSvc> _userServices;

        public List<Product> Products { get => _products; set => Set(ref _products, value, nameof(Products)); }
        public List<ProductCategory> ProductCategories { get => _productCategories; set => Set(ref _productCategories, value, nameof(ProductCategories)); }
        public List<Service> Services { get => _services; set => Set(ref _services, value, nameof(Services)); }
        public List<User> User { get => _user; set => Set(ref _user, value, nameof(User)); }
        public List<UserProduct> UserProducts { get => _userProducts; set => Set(ref _userProducts, value, nameof(UserProducts)); }
        public List<UserSvc> UserServices { get => _userServices; set => Set(ref _userServices, value, nameof(UserServices)); }
        #endregion

        #region Services
        public ProductService ProductService { get; }
       

        #endregion

        #region Product properties & fields
        private string _productSearch;
        private string _selectedProducttFilther;
        private string _selectedProductSort;

        public string ProductSearch { get => _productSearch; set => Set(ref _productSearch, value, nameof(ProductSearch)); }
        public string SelectedProductFilther { get => _selectedProducttFilther; set => _selectedProducttFilther = value; }
        public string SelectedProductSort { get => _selectedProductSort; set => _selectedProductSort = value; }
        #endregion
        public AdminViewModel(ApplicationDbContext ctx)
        {
            ProductService = new ProductService(ctx);

            Products=new List<Product>(ProductService.GetProducts());
        }
    }
}
