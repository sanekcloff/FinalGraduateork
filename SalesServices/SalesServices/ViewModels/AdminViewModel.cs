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
        public ServiceService ServiceService { get; }
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

        #region Service properties & fields
        private string _serviceSearch;
        private string _selectedServiceSort;
        private Service _selectedService;

        public string ServiceSearch
        {
            get => _serviceSearch;
            set
            {
                Set(ref _serviceSearch, value, nameof(ServiceSearch));
                UpdateServicesList();
            }
        }
        public string SelectedServiceSort
        {
            get => _selectedServiceSort;
            set
            {
                Set(ref _selectedServiceSort, value, nameof(SelectedServiceSort));
                UpdateServicesList();
            }
        }
        public Service SelectedService { get => _selectedService; set => Set(ref _selectedService, value, nameof(SelectedService)); }
        public List<string> ServiceSortings { get; } = new List<string>()
        {
            "Без сортировки",
            "По цене (убыв.)",
            "По цене (возр.)",
            "По дате добавления (убыв.)",
            "По дате добавления (возр.)"
        };
        #endregion
        public AdminViewModel(ApplicationDbContext ctx)
        {
            ProductService = new(ctx);
            UserService = new(ctx);
            ServiceService = new(ctx);

            UpdateProductsList();
            UpdateServicesList();
            ProductFilthers.AddRange(ctx.ProductCategories.Select(category => category.Title));
            
            SelectedProductFilther = ProductFilthers[0];
            SelectedProductSort = ProductSortings[0];
            SelectedServiceSort = ServiceSortings[0];
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

        #region Service Methods
        public void UpdateServicesList()
        {
            Services = SortService(SearchService(ServiceService.GetServices())).ToList();
        }
        public ICollection<Service> SearchService(ICollection<Service> services)
        {
            if (ServiceSearch == string.Empty || ServiceSearch == null)
                return services;
            else
                return services
                    .Where(p => p.Title.ToLower().Contains(ServiceSearch.ToLower())
                    || p.Description.ToLower().Contains(ServiceSearch.ToLower()))
                    .ToList();
        }
        public ICollection<Service> SortService(ICollection<Service> services)
        {
            if (SelectedServiceSort == ServiceSortings[1])
                return services.OrderByDescending(s => s.CostPerHour).ToList();
            else if (SelectedServiceSort == ServiceSortings[2])
                return services.OrderBy(s => s.CostPerHour).ToList();
            else if (SelectedServiceSort == ServiceSortings[3])
                return services.OrderByDescending(s => s.DateOfAdd).ToList();
            else if (SelectedServiceSort == ServiceSortings[4])
                return services.OrderBy(s => s.DateOfAdd).ToList();
            else
                return services;
        }
        #endregion
    }
}