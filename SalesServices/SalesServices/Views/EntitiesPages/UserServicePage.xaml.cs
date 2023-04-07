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
    /// Логика взаимодействия для UserServicePage.xaml
    /// </summary>
    public partial class UserServicePage : Page
    {
        private UserServicePageViewModel _viewModel;
        public UserServicePage(UserSvc userSvc, UserServiceService entityService, ServiceService serviceService, UserService userService, StatusService statusService)
        {
            InitializeComponent();
            _viewModel = new(userSvc, entityService, serviceService, userService, statusService);
            DataContext= _viewModel;
            if (!_viewModel.IsNew)
                ControlButton.Content = "Изменить";
        }

        private void ControlButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetUserService();
            if (_viewModel.SelectedService == null
                || _viewModel.SelectedStatus == null
                || _viewModel.SelectedUser == null)
                MessageBox.Show("Все поля должны быть заполнены");
            else
            {
                if (_viewModel.IsNew)
                {
                    if (_viewModel.EntityService.GetUserService(_viewModel.UserService) == null)
                    {
                        _viewModel.EntityService.Insert(_viewModel.UserService);
                        MessageBox.Show($"Услуга {_viewModel.UserService.Service.Title} пользователю {_viewModel.UserService.User.UserProfile.FullName} успешно добавлена!");
                    }
                    else
                        MessageBox.Show($"Такой заказ уже существует!");
                }
                else
                {
                    _viewModel.EntityService.Update(_viewModel.UserService);
                    MessageBox.Show($"Изменения успешно внесены!");
                }
            }
        }
    }
}
