using SalesServices.Entities;
using SalesServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.ViewModels.EntitiesViewModels
{
    public class UserProductPageViewModel
    {
        public UserProductPageViewModel(UserProduct userProduct, UserProductService entityService)
        {
            if (userProduct == null)
                userProduct = new();
        }
    }
}
