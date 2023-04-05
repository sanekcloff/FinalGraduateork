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
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        private ServicePageViewModel _viewModel;
        public ServicePage(Service service, ServiceService entityService)
        {
            InitializeComponent();
            _viewModel = new ServicePageViewModel(service, entityService);
            DataContext= _viewModel;
            if (!_viewModel.IsNew == true)
                ControlButton.Content = "Изменить";
        }

        private void ControlButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetService();
            if ((_viewModel.Title==null || _viewModel.Title==string.Empty)
                || (_viewModel.Description==null || _viewModel.Description==string.Empty))
                MessageBox.Show("Все поля должны быть заполнены!");
            else
            {
                if (_viewModel.IsNew)
                {
                    if (_viewModel.EntityService.GetService(_viewModel.Service) == null)
                    {
                        _viewModel.EntityService.Insert(_viewModel.Service);
                        MessageBox.Show($"Сервис {_viewModel.Title} успешно добавлен!");
                    }
                    else
                        MessageBox.Show($"Такой сервис уже существует!");
                }
                else
                {
                    _viewModel.EntityService.Update(_viewModel.Service);
                    MessageBox.Show($"Изменения успешно внесены!");
                }
            }                
        }
    }
}
