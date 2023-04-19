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
        public bool IsNew = false;
        public ServiceService EntityService { get; }

        private Service _service;

        private string _title;
        private string _description;
        private decimal _costPerHour;

        public Service Service 
        { 
            get => _service;
            set => Set(ref _service, value, nameof(Service));
        }
        public string Title
        {
            get => _title;
            set => Set(ref _title, value, nameof(Title));
        }
        public string Description 
        { 
            get => _description;
            set => Set(ref _description, value, nameof(Description)); 
        }
        public decimal CostPerHour
        {
            get => _costPerHour;
            set
            {
                if (value < 0 || value == null)
                    value = 0;
                Set(ref _costPerHour, value, nameof(CostPerHour));
            }
        }

        public ServicePageViewModel(Service service, ServiceService entityService)
        {
            if (entityService.GetService(service)==null)
                IsNew= true;
            else
            {
                Title = service.Title;
                Description= service.Description;
                CostPerHour = service.CostPerHour;
            }
            CostPerHour=service.CostPerHour;
            EntityService=entityService;
            Service = service;
        }

        public void GetService()
        {
            Service.Title = Title;
            Service.Description = Description;
            Service.CostPerHour = CostPerHour;
        }
    }
}
