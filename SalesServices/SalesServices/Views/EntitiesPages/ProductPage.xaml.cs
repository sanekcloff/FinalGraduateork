using Microsoft.Win32;
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
        public ProductPage(Product product, ProductService entityService, ProductCategoryService productCategoryService)
        {
            InitializeComponent();
            _viewModel = new ProductPageViewModel(product, entityService, productCategoryService);
            DataContext= _viewModel;
            if (!_viewModel.IsNew)
                ControlButton.Content = "Изменить";
        }

        private void UploadPicturePath_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                _viewModel.GetPicturePath(openFileDialog.FileName);
            }
        }

        private void ControlButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetProduct();
            if ((_viewModel.Title == null || _viewModel.Title == string.Empty)
                || (_viewModel.Description == null || _viewModel.Description == string.Empty)
                || (_viewModel.Cost == 0)
                || (_viewModel.SelectedProductCategory == null))
                MessageBox.Show("Все поля должны быть заполнены!");
            else
            {
                if (_viewModel.IsNew)
                {
                    if (_viewModel.EntityService.GetProduct(_viewModel.Product) == null)
                    {
                        _viewModel.EntityService.Insert(_viewModel.Product);
                        MessageBox.Show($"Продукт {_viewModel.Title} успешно добавлен!");
                    }
                    else
                        MessageBox.Show($"Такой продукт уже существует!");
                }
                else
                {
                    _viewModel.EntityService.Update(_viewModel.Product);
                    MessageBox.Show($"Изменения успешно внесены!");
                }
            }  
        }
    }
}