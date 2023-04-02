using SalesServices.Data;
using SalesServices.Entities;
using SalesServices.Services;
using SalesServices.Views;
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
        private List<User> _users;
        private List<UserProduct> _userProducts;
        private List<UserSvc> _userServices;

        public List<Product> Products { get => _products; set => Set(ref _products, value, nameof(Products)); }
        public List<ProductCategory> ProductCategories { get => _productCategories; set => Set(ref _productCategories, value, nameof(ProductCategories)); }
        public List<Service> Services { get => _services; set => Set(ref _services, value, nameof(Services)); }
        public List<User> Users { get => _users; set => Set(ref _users, value, nameof(Users)); }
        public List<UserProduct> UserProducts { get => _userProducts; set => Set(ref _userProducts, value, nameof(UserProducts)); }
        public List<UserSvc> UserServices { get => _userServices; set => Set(ref _userServices, value, nameof(UserServices)); }
        #endregion

        #region Services
        public ProductService ProductService { get; }
        public UserService UserService { get; }
        public ServiceService ServiceService { get; }
        public UserProductService UserProductsService { get; }
        public UserServiceService UserServicesService { get; }
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

        #region User properties & fields
        private string _userSearch;
        private string _selectedUserSort;
        private string _selectedUserFilther;
        private User _selectedUser;

        public string UserSearch
        {
            get => _userSearch;
            set
            {
                Set(ref _userSearch, value, nameof(UserSearch));
                UpdateUsersList();
            }
        }
        public string SelectedUserSort
        {
            get => _selectedUserSort;
            set
            {
                Set(ref _selectedUserSort, value, nameof(SelectedUserSort));
                UpdateUsersList();
            }
        }
        public string SelectedUserFilther
        {
            get => _selectedUserFilther;
            set
            {
                Set(ref _selectedUserFilther, value, nameof(SelectedUserFilther));
                UpdateUsersList();
            }
        }
        public User SelectedUser { get => _selectedUser; set => Set(ref _selectedUser, value, nameof(SelectedUser)); }
        public List<string> UserFilthers { get; } = new List<string>()
        {
            "Все роли"
        };
        public List<string> UserSortings { get; } = new List<string>()
        {
            "Без сортировки",
            "По ФИО (убыв.)",
            "По ФИО (возр.)",
            "По количеству товаров (убыв.)",
            "По количеству товаров (возр.)",
            "По количеству услуг (убыв.)",
            "По количеству услуг (возр.)",
            "По дате регистрации (убыв.)",
            "По дате регистрации (возр.)"
        };
        #endregion

        #region UserProducts properties & fields
        private string _userProductSearch;
        private string _selectedUserProductSort;
        private string _selectedUserProductFilther;
        private UserProduct _selectedUserProduct;

        public string UserProductSearch
        {
            get => _userProductSearch;
            set
            {
                Set(ref _userProductSearch, value, nameof(UserProductSearch));
                UpdateUserProductsList();
            }
        }
        public string SelectedUserProductSort
        {
            get => _selectedUserProductSort;
            set
            {
                Set(ref _selectedUserProductSort, value, nameof(SelectedUserProductSort));
                UpdateUserProductsList();
            }
        }
        public string SelectedUserProductFilther
        {
            get => _selectedUserProductFilther;
            set
            {
                Set(ref _selectedUserProductFilther, value, nameof(SelectedUserProductFilther));
                UpdateUserProductsList();
            }
        }
        public UserProduct SelectedUserProduct { get => _selectedUserProduct; set => Set(ref _selectedUserProduct, value, nameof(SelectedUserProduct)); }
        public List<string> UserProductFilthers { get; } = new List<string>()
        {
            "Все статусы"
        };
        public List<string> UserProductSortings { get; } = new List<string>()
        {
            "Без сортировки",
            "По количеству (убыв.)",
            "По количеству (возр.)",
            "По новизне (убыв.)",
            "По новизне (возр.)",
            "По стоимости (убыв.)",
            "По стоимости (возр.)"
        };
        #endregion

        #region UserProducts properties & fields
        private string _userServiceSearch;
        private string _selectedUserServiceSort;
        private string _selectedUserServiceFilther;
        private UserSvc _selectedUserService;

        public string UserServiceSearch
        {
            get => _userServiceSearch;
            set
            {
                Set(ref _userServiceSearch, value, nameof(UserServiceSearch));
                UpdateUserServicesList();
            }
        }
        public string SelectedUserServiceSort
        {
            get => _selectedUserServiceSort;
            set
            {
                Set(ref _selectedUserServiceSort, value, nameof(SelectedUserServiceSort));
                UpdateUserServicesList();
            }
        }
        public string SelectedUserServiceFilther
        {
            get => _selectedUserServiceFilther;
            set
            {
                Set(ref _selectedUserServiceFilther, value, nameof(SelectedUserServiceFilther));
                UpdateUserServicesList();
            }
        }
        public UserSvc SelectedUserService { get => _selectedUserService; set => Set(ref _selectedUserService, value, nameof(SelectedUserService)); }
        public List<string> UserServiceFilthers { get; } = new List<string>()
        {
            "Все статусы"
        };
        public List<string> UserServiceSortings { get; } = new List<string>()
        {
            "Без сортировки",
            "По новизне (убыв.)",
            "По новизне (возр.)",
            "По стоимости (убыв.)",
            "По стоимости (возр.)"
        };
        #endregion

        public AdminViewModel(ApplicationDbContext ctx)
        {
            ProductService = new(ctx);
            UserService = new(ctx);
            ServiceService = new(ctx);
            UserProductsService = new(ctx);
            UserServicesService = new(ctx);

            UpdateProductsList();
            UpdateServicesList();
            UpdateUsersList();
            UpdateUserProductsList();
            UpdateUserServicesList();

            ProductFilthers.AddRange(ctx.ProductCategories.Select(category => category.Title));
            UserFilthers.AddRange(ctx.Roles.Select(role => role.Title));
            UserProductFilthers.AddRange(ctx.Statuses.Select(statuses => statuses.Title));
            UserServiceFilthers.AddRange(ctx.Statuses.Select(statuses=>statuses.Title));
            
            SelectedProductFilther = ProductFilthers[0];
            SelectedProductSort = ProductSortings[0];
            SelectedServiceSort = ServiceSortings[0];
            SelectedUserSort= UserSortings[0];
            SelectedUserFilther = UserFilthers[0];
            SelectedUserProductFilther = UserProductFilthers[0];
            SelectedUserProductSort = UserProductSortings[0];
            SelectedUserServiceFilther = UserServiceFilthers[0];
            SelectedUserServiceSort = UserServiceSortings[0];
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

        public void CleanProduct()
        {
            SelectedProduct = null!;
            SelectedProductFilther = ProductFilthers[0];
            SelectedProductSort = ProductSortings[0];
            ProductSearch = null!;
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

        public void CleanService()
        {
            SelectedService = null!;
            SelectedServiceSort = ServiceSortings[0];
            ServiceSearch = null!;
        }
        #endregion

        #region User Methods
        public void UpdateUsersList()
        {
            Users = SortUser(SearchUser(FiltherUser(UserService.GetUsers()))).ToList();
        }
        public ICollection<User> SearchUser(ICollection<User> users)
        {
            if (UserSearch == string.Empty || UserSearch == null)
                return users;
            else
                return users
                    .Where(u=>u.UserProfile.FullName.ToLower().Contains(UserSearch.ToLower()))
                    .ToList();
        }
        public ICollection<User> FiltherUser(ICollection<User> users)
        {
            if (SelectedUserFilther == UserFilthers[0])
                return users;
            else
                return users
                    .Where(u => u.Role.Title == SelectedUserFilther)
                    .ToList();
        }
        public ICollection<User> SortUser(ICollection<User> users)
        {
            if (SelectedUserSort == UserSortings[1])
                return users.OrderByDescending(u => u.UserProfile.FullName).ToList();
            else if (SelectedUserSort == UserSortings[2])
                return users.OrderBy(u => u.UserProfile.FullName).ToList();
            else if (SelectedUserSort == UserSortings[3])
                return users.OrderByDescending(u => u.UserProfile.NumberOfPurchases).ToList();
            else if (SelectedUserSort == UserSortings[4])
                return users.OrderBy(u => u.UserProfile.NumberOfPurchases).ToList();
            else if (SelectedUserSort == UserSortings[5])
                return users.OrderByDescending(u => u.UserProfile.NumberOfServices).ToList();
            else if (SelectedUserSort == UserSortings[6])
                return users.OrderBy(u => u.UserProfile.NumberOfServices).ToList();
            else if (SelectedUserSort == UserSortings[5])
                return users.OrderByDescending(u => u.UserProfile.DateOfRegister).ToList();
            else if (SelectedUserSort == UserSortings[6])
                return users.OrderBy(u => u.UserProfile.DateOfRegister).ToList();
            else
                return users;
        }

        public void CleanUser()
        {
            SelectedUser = null!;
            SelectedUserSort = UserSortings[0];
            SelectedUserFilther = UserFilthers[0];
            UserSearch = null!;
        }
        #endregion

        #region UserProducts Methods
        public void UpdateUserProductsList()
        {
            UserProducts = SortUserProduct(SearchUserProduct(FiltherUserProduct(UserProductsService.GetUserProducts()))).ToList();
        }
        public ICollection<UserProduct> SearchUserProduct(ICollection<UserProduct> userProducts)
        {
            if (UserProductSearch == string.Empty || UserProductSearch == null)
                return userProducts;
            else
                return userProducts
                    .Where(up => up.Product.Title.ToLower().Contains(UserProductSearch.ToLower())
                    || up.User.UserProfile.FullName.ToLower().Contains(UserProductSearch.ToLower()))
                    .ToList();
        }
        public ICollection<UserProduct> FiltherUserProduct(ICollection<UserProduct> userProducts)
        {
            if (SelectedUserProductFilther == UserProductFilthers[0])
                return userProducts;
            else
                return userProducts
                    .Where(up => up.Status.Title==SelectedUserProductFilther)
                    .ToList();
        }
        public ICollection<UserProduct> SortUserProduct(ICollection<UserProduct> userProducts)
        {
            if (SelectedUserSort == UserSortings[1])
                return userProducts.OrderByDescending(up => up.Quantity).ToList();
            else if (SelectedUserSort == UserSortings[2])
                return userProducts.OrderBy(up => up.Quantity).ToList();
            else if (SelectedUserSort == UserSortings[3])
                return userProducts.OrderByDescending(up => up.DateOfOrder).ToList();
            else if (SelectedUserSort == UserSortings[4])
                return userProducts.OrderBy(up => up.DateOfOrder).ToList();
            else if (SelectedUserSort == UserSortings[5])
                return userProducts.OrderByDescending(up => up.FullCost).ToList();
            else if (SelectedUserSort == UserSortings[6])
                return userProducts.OrderBy(up => up.FullCost).ToList();
            else
                return userProducts;
        }
        public void CleanUserProduct()
        {
            SelectedUserProduct = null!;
            SelectedUserProductFilther = UserProductFilthers[0];
            SelectedUserProductSort = UserProductSortings[0];
            UserProductSearch = null!;
        }
        #endregion

        #region UserProducts Methods
        public void UpdateUserServicesList()
        {
            UserServices = SortUserService(SearchUserService(FiltherUserService(UserServicesService.GetUserServices()))).ToList();
        }
        public ICollection<UserSvc> SearchUserService(ICollection<UserSvc> userServices)
        {
            if (UserServiceSearch == string.Empty || UserServiceSearch == null)
                return userServices;
            else
                return userServices
                    .Where(up => up.Service.Title.ToLower().Contains(UserServiceSearch.ToLower())
                    || up.User.UserProfile.FullName.ToLower().Contains(UserServiceSearch.ToLower()))
                    .ToList();
        }
        public ICollection<UserSvc> FiltherUserService(ICollection<UserSvc> userServices)
        {
            if (SelectedUserServiceFilther == UserServiceFilthers[0])
                return userServices;
            else
                return userServices
                    .Where(us => us.Status.Title == SelectedUserServiceFilther)
                    .ToList();
        }
        public ICollection<UserSvc> SortUserService(ICollection<UserSvc> userServices)
        {
            if (SelectedUserSort == UserSortings[3])
                return userServices.OrderByDescending(us => us.DateOfOrder).ToList();
            else if (SelectedUserSort == UserSortings[4])
                return userServices.OrderBy(us => us.DateOfOrder).ToList();
            else if (SelectedUserSort == UserSortings[5])
                return userServices.OrderByDescending(us => us.Service.CostPerHour).ToList();
            else if (SelectedUserSort == UserSortings[6])
                return userServices.OrderBy(us => us.Service.CostPerHour).ToList();
            else
                return userServices;
        }
        public void CleanUserService()
        {
            SelectedUserService = null!;
            SelectedUserServiceFilther = UserServiceFilthers[0];
            SelectedUserServiceSort = UserServiceSortings[0];
            UserServiceSearch = null!;
        }
        #endregion

        public void OpenManagerWindow(object? obj)
        {
            if (obj is Product)
                new ManagerWindow(obj as Product, ProductService).ShowDialog();
            else if (obj is Service)
                new ManagerWindow(obj as Service, ServiceService).ShowDialog();
            else if (obj is User)
                new ManagerWindow(obj as User, UserService).ShowDialog();
            else if (obj is UserProduct)
                new ManagerWindow(obj as UserProduct, UserProductsService).ShowDialog();
            else if (obj is UserSvc)
                new ManagerWindow(obj as UserSvc, UserServicesService).ShowDialog();
        }
    }
}