using SalesServices.Data;
using SalesServices.Entities;
using SalesServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesServices.ViewModels
{
    public class RegisterViewModel:ViewModelBase
    {
        private string _lastName;
        private string _firstName;
        private string _middleName;
        private string _email;
        private string _phone;
        private DateTime _dateOfBirth;
        private string _login;
        private string _password;

        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string MiddleName { get => _middleName; set => _middleName = value; }
        public string Email { get => _email; set => _email = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public string Login { get => _login; set => _login = value; }
        public string Password { get => _password; set => _password = value; }

        public UserService UserService { get; }

        public RegisterViewModel(ApplicationDbContext ctx)
        {
            UserService = new(ctx);

            DateOfBirth=DateTime.Now;
        }
        public void Register()
        {
            var user = new User
            {
                Login = Login,
                Password = Password,
                RoleId = 3
            };

            var userProfile = new UserProfile
            {
                FirstName = FirstName,
                LastName = LastName,
                MiddleName = MiddleName,
                Email = Email,
                Phone = Phone,
                DateOfBirth = DateOfBirth,
                DateOfRegister = DateTime.Now,
                NumberOfPurchases=0,
                NumberOfServices=0,
                User=user
            };

            if (LastName != null
                || FirstName != null
                || MiddleName != null
                || Email != null
                || Phone != null
                || Login != null
                || Password != null)
            {
                if (UserService.GetUser(Login, Password) == null)
                    UserService.Insert(user, userProfile);
                else MessageBox.Show("Используйте другой логин и пароль");
            }
            else MessageBox.Show("Все поля должны быть заполнены!");
            
        }
    }
}
