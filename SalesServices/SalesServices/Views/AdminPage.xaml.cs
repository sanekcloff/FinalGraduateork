using SalesServices.Data;
using SalesServices.Entities;
using SalesServices.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesServices.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private AdminViewModel _viewModel;
        public AdminPage(ApplicationDbContext ctx)
        {
            InitializeComponent();
            _viewModel = new AdminViewModel(ctx);
            DataContext = _viewModel;
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(new Product() { DateOfAdd=DateTime.Now, Discount=1});
            _viewModel.UpdateProductsList();
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(_viewModel.SelectedProduct);
            _viewModel.UpdateProductsList();
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Вы уверены что хотите удалить {_viewModel.SelectedProduct.Title}?","Внимание!",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                _viewModel.ProductService.Delete(_viewModel.SelectedProduct);
                _viewModel.UpdateProductsList();
            }
        }

        private void CleanProductButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CleanProduct();
        }

        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(new Service() { DateOfAdd = DateTime.Now, CostPerHour=0 });
            _viewModel.UpdateServicesList();
        }

        private void EditServiceButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(_viewModel.SelectedService);
            _viewModel.UpdateServicesList();
        }

        private void DeleteServiceButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Вы уверены что хотите удалить {_viewModel.SelectedService.Title}?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _viewModel.ServiceService.Delete(_viewModel.SelectedService);
                _viewModel.UpdateServicesList();
            }
        }

        private void CleanServiceButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CleanService();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(new User());
            _viewModel.UpdateUsersList();
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(_viewModel.SelectedUser);
            _viewModel.UpdateUsersList();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Вы уверены что хотите удалить {_viewModel.SelectedUser.UserProfile.FullName}?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _viewModel.UserService.Delete(_viewModel.SelectedUser, _viewModel.SelectedUser.UserProfile);
                _viewModel.UpdateUsersList();
            }
        }

        private void CleanUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CleanUser();
        }

        private void AddUserProductButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(new UserProduct() { DateOfOrder=DateTime.Now });
            _viewModel.UpdateUserProductsList();
            _viewModel.UpdateUsersList();
        }

        private void EditUserProductButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(_viewModel.SelectedUserProduct);
            _viewModel.UpdateUserProductsList();
            _viewModel.UpdateUsersList();
        }

        private void DeleteUserProductButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Вы уверены что хотите удалить заказ продукта {_viewModel.SelectedUserProduct.Product.Title} пользователя {_viewModel.SelectedUserProduct.User.UserProfile.FullName}?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _viewModel.UserProductsService.Delete(_viewModel.SelectedUserProduct);
                _viewModel.UpdateUserProductsList();
                _viewModel.UpdateUsersList();
            }
        }

        private void CleanUserProductButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CleanUserProduct();
        }

        private void AddUserServiceButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(new UserSvc() { DateOfOrder = DateTime.Now });
            _viewModel.UpdateUserServicesList();
            _viewModel.UpdateUsersList();
        }

        private void EditUserServiceButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(_viewModel.SelectedUserService);
            _viewModel.UpdateUserServicesList();
            _viewModel.UpdateUsersList();
        }

        private void DeleteUserServiceButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Вы уверены что хотите удалить заказ услуги {_viewModel.SelectedUserProduct.Product.Title} пользователя {_viewModel.SelectedUserProduct.User.UserProfile.FullName}?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _viewModel.UserServicesService.Delete(_viewModel.SelectedUserService);
                _viewModel.UpdateUserServicesList();
                _viewModel.UpdateUsersList();
            }
        }

        private void CleanUserServiceButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CleanUserService();
        }
    }
}
