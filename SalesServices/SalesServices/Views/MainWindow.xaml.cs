using SalesServices.Data;
using SalesServices.Entities;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow(User user, ApplicationDbContext ctx)
        {
            InitializeComponent();
            Title=$"{user.Role.Title}: {user.UserProfile.FullName}";
            if (user.Role.ID == 1) MainFrame.Navigate(new AdminPage(ctx));
            else if (user.Role.ID==2) MainFrame.Navigate(new EmployeePage(ctx));
            else MainFrame.Navigate(new ClientPage(ctx));
        }
    }
}
