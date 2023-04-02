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
        }
    }
}
