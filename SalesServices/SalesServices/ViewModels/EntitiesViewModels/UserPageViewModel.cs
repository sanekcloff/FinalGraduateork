using SalesServices.Entities;
using SalesServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.ViewModels.EntitiesViewModels
{
    public class UserPageViewModel
    {
        public UserPageViewModel(User user, UserService entityService)
        {
            if (user == null)
                user = new();
        }
    }
}
