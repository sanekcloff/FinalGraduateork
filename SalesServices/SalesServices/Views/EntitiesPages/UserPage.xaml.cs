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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private UserPageViewModel _viewModel;
        public UserPage(User user, UserService entityService)
        {
            InitializeComponent();
            _viewModel = new(user, entityService);
            DataContext = _viewModel;
            if (!_viewModel.IsNew)
                ControlButton.Content = "Изменить";
        }

        private void ControlButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetUser();
            if ((_viewModel.Login == null || _viewModel.Login == string.Empty)
                || (_viewModel.Password == null || _viewModel.Password == string.Empty)
                || (_viewModel.UserProfile.LastName == null || _viewModel.UserProfile.LastName == string.Empty)
                || (_viewModel.UserProfile.FirstName == null || _viewModel.UserProfile.FirstName == string.Empty)
                || (_viewModel.UserProfile.MiddleName == null || _viewModel.UserProfile.MiddleName == string.Empty)
                || (_viewModel.UserProfile.Phone == null || _viewModel.UserProfile.Phone == string.Empty)
                || (_viewModel.UserProfile.Email == null || _viewModel.UserProfile.Email == string.Empty))
                MessageBox.Show("Все поля должны быть заполнены!");
            else
            {
                if (_viewModel.IsNew)
                {
                    if (_viewModel.EntityService.GetUser(_viewModel.User)==null)
                    {
                        _viewModel.EntityService.Insert(_viewModel.User, _viewModel.UserProfile);
                        MessageBox.Show($"Пользователь {_viewModel.UserProfile.FullName} успешно добавлен!");
                    }
                    else
                        MessageBox.Show($"Такой пользователь уже существует!");
                }
                else
                {
                    _viewModel.EntityService.Update(_viewModel.User, _viewModel.UserProfile);
                    MessageBox.Show($"Изменения успешно внесены!");
                }
            }
        }
    }
}
