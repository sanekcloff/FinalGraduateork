using SalesServices.Data;
using SalesServices.Services;
using SalesServices.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesServices.ViewModels
{
    public class AuthorizationViewModel:ViewModelBase
    {
        private string _login=null!;
        private string _password=null!;

        public string Login { get => _login; set => Set(ref _login, value, nameof(Login)); }
        public string Password { get => _password; set => Set(ref _password, value, nameof(Password)); }

        public UserService UserService { get; } = null!;
        private ApplicationDbContext _ctx;

        public AuthorizationViewModel()
        {
            _ctx=new ApplicationDbContext();

            UserService = new UserService(_ctx);
        }

        public void Authorization()
        {
            var user = UserService.GetUser(Login, Password);
            if (user != null) new MainWindow(user, _ctx).ShowDialog();
            else MessageBox.Show("Некоректные данные!");
        }
    }
}
