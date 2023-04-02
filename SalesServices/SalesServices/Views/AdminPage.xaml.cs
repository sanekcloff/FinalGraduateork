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
            _viewModel.OpenManagerWindow(new Product());
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(_viewModel.SelectedProduct);
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ProductService.Delete(_viewModel.SelectedProduct);
        }

        private void CleanProductButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CleanProduct();
        }

        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(new Service());
        }

        private void EditServiceButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(_viewModel.SelectedService);
        }

        private void DeleteServiceButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ServiceService.Delete(_viewModel.SelectedService);
        }

        private void CleanServiceButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CleanService();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(new User());
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(_viewModel.SelectedUser);
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UserService.Delete(_viewModel.SelectedUser, _viewModel.SelectedUser.UserProfile);
        }

        private void CleanUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CleanUser();
        }

        private void AddUserProductButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(new UserProduct());
        }

        private void EditUserProductButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(_viewModel.SelectedUserProduct);
        }

        private void DeleteUserProductButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UserProductsService.Delete(_viewModel.SelectedUserProduct);
        }

        private void CleanUserProductButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CleanUserProduct();
        }

        private void AddUserServiceButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(new UserSvc());
        }

        private void EditUserServiceButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OpenManagerWindow(_viewModel.SelectedUserService);
        }

        private void DeleteUserServiceButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UserServicesService.Delete(_viewModel.SelectedUserService);
        }

        private void CleanUserServiceButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CleanUserService();
        }
    }
}
