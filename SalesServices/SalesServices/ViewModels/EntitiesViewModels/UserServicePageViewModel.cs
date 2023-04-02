using SalesServices.Entities;
using SalesServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.ViewModels.EntitiesViewModels
{
    public class UserServicePageViewModel
    {
        public UserServicePageViewModel(UserSvc userService, UserServiceService entityService)
        {
            if (userService == null)
                userService = new();
        }
    }
}
