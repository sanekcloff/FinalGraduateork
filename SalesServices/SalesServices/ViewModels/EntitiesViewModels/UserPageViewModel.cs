using SalesServices.Entities;
using SalesServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.ViewModels.EntitiesViewModels
{
    public class UserPageViewModel:ViewModelBase
    {
        public bool IsNew=false;

        public UserService EntityService { get; }

        private User _user;
        private string _login;
        private string _password;
        private Role _selectedRole;
        private UserProfile _userProfile;

        public User User { get => _user; set => Set(ref _user, value, nameof(User)); }
        public string Login
        {
            get => _login;
            set
            {
                Set(ref _login, value, nameof(Login));
            }
        }
        public string Password { get => _password; set => Set(ref _password, value, nameof(Password)); }
        public Role SelectedRole { get => _selectedRole; set => Set(ref _selectedRole, value, nameof(SelectedRole)); }
        public UserProfile UserProfile { get => _userProfile; set => Set(ref _userProfile, value, nameof(UserProfile)); }
        public List<Role> Roles { get; }
        public UserPageViewModel(User user, UserService entityService, RoleService roleService)
        {
            Roles = new List<Role>(roleService.GetRoles());
            if (entityService.GetUser(user)==null)
            {
                IsNew = true;
                UserProfile = new()
                {
                    DateOfRegister = DateTime.Now,
                    DateOfBirth=DateTime.Now
                };
                SelectedRole = Roles[Roles.Count - 1];
            }
            else
            {
                UserProfile = user.UserProfile;
                SelectedRole = user.Role;
                Login=user.Login;
                Password=user.Password;
            }
            EntityService=entityService;
            User = user; 
        }
        
        public void GetUser()
        {
            User.Login = Login;
            User.Password = Password;
            User.Role = SelectedRole;
            
            UserProfile.User= User;
        }
    }
}
