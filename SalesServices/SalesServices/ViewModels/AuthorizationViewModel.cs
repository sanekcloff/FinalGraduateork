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
        public ApplicationDbContext Ctx;

        public AuthorizationViewModel()
        {
            Ctx=new ApplicationDbContext();

            UserService = new UserService(Ctx);
        }

        public void Authorization()
        {
            var user = UserService.GetUser(Login, Password);
            if (user != null) new MainWindow(user);
            else MessageBox.Show("Некоректные данные!");
        }
    }
}
