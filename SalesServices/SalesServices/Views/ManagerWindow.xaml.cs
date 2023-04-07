using SalesServices.Entities;
using SalesServices.Services;
using SalesServices.Views.EntitiesPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalesServices.Views
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow(Product product, ProductService productService, ProductCategoryService productCategoryService)
        {
            InitializeComponent();
            if (productService.GetProduct(product) == null)
            {
                Title = "Добавление продукта";
                Icon = BitmapFrame.Create(new Uri("pack://application:,,,/Resources/Icons/AddIcon.ico", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Title = "Редактирование продукта";
                Icon = BitmapFrame.Create(new Uri("pack://application:,,,/Resources/Icons/EditIcon.ico", UriKind.RelativeOrAbsolute));
            }
            ManagerFrame.Navigate(new ProductPage(product, productService, productCategoryService));
        }
        public ManagerWindow(Service service, ServiceService serviceService)
        {
            InitializeComponent();
            if (serviceService.GetService(service)==null)
            {
                Title = "Добавление услуги";
                Icon = BitmapFrame.Create(new Uri("pack://application:,,,/Resources/Icons/AddIcon.ico", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Title = "Редактирование услуги";
                Icon = BitmapFrame.Create(new Uri("pack://application:,,,/Resources/Icons/EditIcon.ico", UriKind.RelativeOrAbsolute));
            } 
            ManagerFrame.Navigate(new ServicePage(service, serviceService));
        }
        public ManagerWindow(User user, UserService userService, RoleService roleService)
        {
            InitializeComponent();
            if (userService.GetUser(user) == null)
            {
                Title = "Добавление пользователя";
                Icon = BitmapFrame.Create(new Uri("pack://application:,,,/Resources/Icons/AddIcon.ico", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Title = "Редактирование пользователя";
                Icon = BitmapFrame.Create(new Uri("pack://application:,,,/Resources/Icons/EditIcon.ico", UriKind.RelativeOrAbsolute));
            } 
            ManagerFrame.Navigate(new UserPage(user, userService, roleService));
        }
        public ManagerWindow(UserProduct userProduct, UserProductService userProductService, ProductService productService, UserService userService, StatusService statusService)
        {
            InitializeComponent();
            if (userProductService.GetUserProduct(userProduct)==null)
            {
                Title = "Добавление заказа товара";
                Icon = BitmapFrame.Create(new Uri("pack://application:,,,/Resources/Icons/AddIcon.ico", UriKind.RelativeOrAbsolute));
            }
            else
            {
                Title = "Редактирование заказа товара";
                Icon = BitmapFrame.Create(new Uri("pack://application:,,,/Resources/Icons/EditIcon.ico", UriKind.RelativeOrAbsolute));
            }
            ManagerFrame.Navigate(new UserProductPage(userProduct, userProductService, productService, userService, statusService));
        }
        public ManagerWindow(UserSvc userSvc, UserServiceService userServiceService, ServiceService serviceService, UserService userService, StatusService statusService)
        {
            InitializeComponent();
            if (userServiceService.GetUserService(userSvc)==null)
            {
                Title = "Добавление заказа услуги";
                Icon = BitmapFrame.Create(new Uri("pack://application:,,,/Resources/Icons/AddIcon.ico", UriKind.RelativeOrAbsolute));
            }  
            else
            {
                Title = "Редактирование заказа услуги";
                Icon = BitmapFrame.Create(new Uri("pack://application:,,,/Resources/Icons/EditIcon.ico", UriKind.RelativeOrAbsolute));
            }
            ManagerFrame.Navigate(new UserServicePage(userSvc, userServiceService, serviceService, userService, statusService));
        }
    }
}
