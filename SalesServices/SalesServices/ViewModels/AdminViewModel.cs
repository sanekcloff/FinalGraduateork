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
        public UserService UserService { get; }
        #endregion

        #region Product properties & fields
        private string _productSearch;
        private string _selectedProductFilther;
        private string _selectedProductSort;
        private Product _selectedProduct;

        public string ProductSearch
        {
            get => _productSearch;
            set
            {
                Set(ref _productSearch, value, nameof(ProductSearch));
                UpdateProductsList();
            }
        }
        public string SelectedProductFilther
        {
            get => _selectedProductFilther; 
            set
            {
                Set(ref _selectedProductFilther, value, nameof(SelectedProductFilther));
                UpdateProductsList();
            }
        }
        public string SelectedProductSort
        {
            get => _selectedProductSort; 
            set
            {
                Set(ref _selectedProductSort, value, nameof(SelectedProductSort));
                UpdateProductsList();
            }
        }
        public Product SelectedProduct { get => _selectedProduct; set => Set(ref _selectedProduct, value, nameof(SelectedProduct)); }
        public List<string> ProductFilthers { get; } = new List<string>()
        {
            "Все категории"
        };
        public List<string> ProductSortings { get; } = new List<string>()
        {
            "Без сортировки",
            "По цене (убыв.)",
            "По цене (возр.)",
            "По категории (убыв.)",
            "По категории (возр.)",
            "По дате добавления (убыв.)",
            "По дате добавления (возр.)"
        };
        #endregion
        public AdminViewModel(ApplicationDbContext ctx)
        {
            ProductService = new(ctx);
            UserService = new(ctx);

            UpdateProductsList();
            ProductFilthers.AddRange(ctx.ProductCategories.Select(category => category.Title));
            
            SelectedProductFilther = ProductFilthers[0];
            SelectedProductSort = ProductSortings[0];
        }

        #region Product Methods
        public void UpdateProductsList()
        {
            Products = SortProduct(SearchProduct(FiltherProduct(ProductService.GetProducts()))).ToList();
        }
        public ICollection<Product> SearchProduct(ICollection<Product> products)
        {
            if (ProductSearch == string.Empty || ProductSearch==null)
                return products;
            else
                return products
                    .Where(p => p.Title.ToLower().Contains(ProductSearch.ToLower()) 
                    || p.Description.ToLower().Contains(ProductSearch.ToLower()))
                    .ToList();
        }
        public ICollection<Product> FiltherProduct(ICollection<Product> products)
        {
            if (SelectedProductFilther == ProductFilthers[0])
                return products;
            else
                return products
                    .Where(p => p.ProductCategory.Title == SelectedProductFilther)
                    .ToList();
        }
        public ICollection<Product> SortProduct(ICollection<Product> products)
        {
            if (SelectedProductSort == ProductSortings[1])
                return products.OrderByDescending(p => p.CorrectCost).ToList();
            else if (SelectedProductSort == ProductSortings[2])
                return products.OrderBy(p => p.CorrectCost).ToList();
            else if (SelectedProductSort == ProductSortings[3])
                return products.OrderByDescending(p => p.ProductCategory.Title).ToList();
            else if (SelectedProductSort == ProductSortings[4])
                return products.OrderBy(p => p.ProductCategory.Title).ToList();
            else if (SelectedProductSort == ProductSortings[5])
                return products.OrderByDescending(p => p.DateOfAdd).ToList();
            else if (SelectedProductSort == ProductSortings[6])
                return products.OrderBy(p => p.DateOfAdd).ToList();
            else
                return products;
        }
        #endregion
    }
}