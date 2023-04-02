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
        public UserProductPage(UserProduct userProduct, UserProductService entityService)
        {
            InitializeComponent();
            _viewModel = new(userProduct, entityService);
            DataContext= _viewModel;
        }
    }
}
