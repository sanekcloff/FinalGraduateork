using SalesServices.Entities;
using SalesServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.ViewModels.EntitiesViewModels
{
    public class UserProductPageViewModel:ViewModelBase
    {
        public bool IsNew=false;
        public UserProductService EntityService { get; }
        public UserService UserService { get; }

        private UserProduct _userProduct;
        private Product _selectedProduct;
        private User _selectedUser;
        private int _quantity;
        private Status _selectedStatus;

        public UserProduct UserProduct { get => _userProduct; set => Set(ref _userProduct, value, nameof(UserProduct)); }
        public Product SelectedProduct { get => _selectedProduct; set => Set(ref _selectedProduct, value, nameof(SelectedProduct)); }
        public User SelectedUser { get => _selectedUser; set => Set(ref _selectedUser, value, nameof(SelectedUser)); }
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 1)
                    value = 1;
                else if (value > 50)
                    value = 50;
                Set(ref _quantity, value, nameof(Quantity));
            }
        }
        public Status SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                Set(ref _selectedStatus, value, nameof(SelectedStatus));
                if (value.ID == 3)
                    UserProduct.DateOfCompletion = DateTime.Now;
                else
                    UserProduct.DateOfCompletion = null;
            }
        }

        public List<Status> Statuses { get; }
        public List<Product> Products { get; }
        public List<User> Users { get; }


        public UserProductPageViewModel(UserProduct userProduct, UserProductService entityService, ProductService productService, UserService userService, StatusService statusService)
        {
            EntityService = entityService;
            UserService = userService;
            UserProduct = userProduct;
            if (entityService.GetUserProduct(userProduct)==null)
            {
                IsNew = true;
                Quantity= 1;
            }
            else
            {
                SelectedStatus = userProduct.Status;
                SelectedProduct=userProduct.Product;
                SelectedUser=userProduct.User;
                Quantity=userProduct.Quantity;
            }
            Statuses = new(statusService.GetStatuses());
            Products= new(productService.GetProducts().OrderBy(p=>p.ProductCategory.Title));
            Users = new(userService.GetUsers());
            
        }

        public void GetUserProduct()
        {
            UserProduct.Product = SelectedProduct;
            UserProduct.User = SelectedUser;
            UserProduct.Status = SelectedStatus;
            UserProduct.Quantity=Quantity;
            UserProduct.DateOfOrder = DateTime.Now;
        }
    }
}
