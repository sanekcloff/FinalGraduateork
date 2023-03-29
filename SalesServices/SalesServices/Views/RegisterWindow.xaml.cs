using SalesServices.Data;
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
using System.Windows.Shapes;

namespace SalesServices.Views
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private RegisterViewModel _viewModel;
        public RegisterWindow(ApplicationDbContext ctx)
        {
            InitializeComponent();
            _viewModel = new RegisterViewModel(ctx);
            DataContext= _viewModel;
        }

        private void RegistrtionButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Register();
        }
    }
}
