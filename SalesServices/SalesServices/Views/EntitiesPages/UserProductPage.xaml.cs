using SalesServices.Entities;
using SalesServices.Services;
using SalesServices.ViewModels.EntitiesViewModels;
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

namespace SalesServices.Views.EntitiesPages
{
    /// <summary>
    /// Логика взаимодействия для UserProductPage.xaml
    /// </summary>
    public partial class UserProductPage : Page
    {
        private UserProductPageViewModel _viewModel;
        public UserProductPage(UserProduct userProduct, UserProductService entityService, ProductService productService, UserService userService, StatusService roleService)
        {
            InitializeComponent();
            _viewModel = new(userProduct, entityService, productService, userService, roleService);
            DataContext= _viewModel;
            if (!_viewModel.IsNew)
                ControlButton.Content = "Изменить";
        }

        private void ControlButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetUserProduct();
            if (_viewModel.SelectedProduct==null 
                || _viewModel.SelectedStatus==null
                || _viewModel.SelectedUser==null
                || _viewModel.Quantity==null)
                MessageBox.Show("Все поля должны быть заполнены!");
            else
            {
                if (_viewModel.IsNew)
                {
                    if (_viewModel.EntityService.GetUserProduct(_viewModel.UserProduct)==null)
                    {
                        _viewModel.EntityService.Insert(_viewModel.UserProduct);
                        MessageBox.Show($"Заказ {_viewModel.UserProduct.Product.Title} пользователю {_viewModel.UserProduct.User.UserProfile.FullName} успешно добавлен!");
                    }
                    else
                        MessageBox.Show($"Такой заказ уже существует!");
                }
                else
                {
                    _viewModel.EntityService.Update(_viewModel.UserProduct);
                    MessageBox.Show($"Изменения успешно внесены!");
                }
            }
        }
    }
}
