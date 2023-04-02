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
        public ManagerWindow(Product product, ProductService productService)
        {
            InitializeComponent();
            if (productService.GetProduct(product) == null)
                Title = "Добавление продукта";
            else
                Title = "Редактирование продукта";
            ManagerFrame.Navigate(new ProductPage(product, productService));
        }
        public ManagerWindow(Service service, ServiceService serviceService)
        {
            InitializeComponent();
            if (serviceService.GetService(service)==null)
                Title = "Добавление услуги";
            else
                Title = "Редактирование услуги";
            ManagerFrame.Navigate(new ServicePage(service, serviceService));
        }
        public ManagerWindow(User user, UserService userService)
        {
            InitializeComponent();
            if (userService.GetUser(user) == null)
                Title = "Добавление пользователя";
            else
                Title = "Редактирование пользователя";
            ManagerFrame.Navigate(new UserPage(user, userService));
        }
        public ManagerWindow(UserProduct userProduct, UserProductService userProductService)
        {
            InitializeComponent();
            if (userProductService.GetUserProduct(userProduct)==null)
                Title = "Добавление заказа товара";
            else
                Title = "Редактирование заказа товара";
            ManagerFrame.Navigate(new UserProductPage(userProduct, userProductService));
        }
        public ManagerWindow(UserSvc userService, UserServiceService userServiceService)
        {
            InitializeComponent();
            if (userServiceService.GetUserService(userService)==null)
                Title = "Добавление заказа услуги";
            else
                Title = "Редактирование заказа услуги";
            ManagerFrame.Navigate(new UserServicePage(userService, userServiceService));
        }
    }
}
