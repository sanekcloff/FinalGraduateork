using SalesServices.Entities;
using SalesServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.ViewModels.EntitiesViewModels
{
    public class UserServicePageViewModel:ViewModelBase
    {
        public bool IsNew = false;

        public UserServiceService EntityService;

        private UserSvc _userService;
        private Service _selectedService;
        private User _selectedUser;
        private Status _selectedStatus;

        public UserSvc UserService 
        { 
            get => _userService; 
            set => Set(ref _userService, value, nameof(UserService)); 
        }
        public Service SelectedService 
        { 
            get => _selectedService;
            set => Set(ref _selectedService, value, nameof(SelectedService));
        }
        public User SelectedUser 
        { 
            get => _selectedUser; 
            set => Set(ref _selectedUser, value, nameof(SelectedUser)); 
        }
        public Status SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                Set(ref _selectedStatus, value, nameof(SelectedStatus));
                if (value.ID == 3)
                    UserService.DateOfCompletion = DateTime.Now;
                else
                    UserService.DateOfCompletion = null;
            }
        }

        public List<Service> Services { get; }
        public List<User> Users { get; }
        public List<Status> Statuses { get; }

        public UserServicePageViewModel(UserSvc userSvc, UserServiceService entityService, ServiceService serviceService, UserService userService, StatusService statusService)
        {
            EntityService = entityService;
            UserService = userSvc;
            if (entityService.GetUserService(userSvc)==null)
            { 
                IsNew= true;
            }
            else
            {
                SelectedService = userSvc.Service;
                SelectedUser = userSvc.User;
                SelectedStatus=userSvc.Status;
            }

            Services = new List<Service>(serviceService.GetServices());
            Users = new List<User>(userService.GetUsers());
            Statuses = new List<Status>(statusService.GetStatuses());
        }

        public void GetUserService()
        {
            UserService.Service = SelectedService;
            UserService.User=SelectedUser;
            UserService.Status = SelectedStatus;
        }
    }
}
