using SalesServices.Entities;
using SalesServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.ViewModels.EntitiesViewModels
{
    public class ServicePageViewModel:ViewModelBase
    {
        public ServicePageViewModel(Service service, ServiceService entityService)
        {
            if (service==null)
                service=new();
        }
    }
}
