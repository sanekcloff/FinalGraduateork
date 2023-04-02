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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private ProductPageViewModel _viewModel;
        public ProductPage(Product product, ProductService entityService)
        {
            InitializeComponent();
            _viewModel = new ProductPageViewModel(product, entityService);
            DataContext= _viewModel;
        }
    }
}
