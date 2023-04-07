using SalesServices.Entities;
using SalesServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesServices.ViewModels.EntitiesViewModels
{
    public class ProductPageViewModel:ViewModelBase
    {
        public bool IsNew=false;
        public ProductService EntityService { get; }

        private Product _product;

        private string _title;
        private string _description;
        private ProductCategory _selectedProductCategory;
        private decimal _cost;
        private decimal _discount;
        private string _selectedPicture;
        private int _displayingDiscount;

        public Product Product
        {
            get => _product;
            set
            {
                Set(ref _product, value, nameof(Product));
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                Set(ref _title, value, nameof(Title));
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                Set(ref _description, value, nameof(Description));
            }
        }
        public ProductCategory SelectedProductCategory
        {
            get => _selectedProductCategory;
            set
            {
                Set(ref _selectedProductCategory, value, nameof(SelectedProductCategory));
            }
        }
        public decimal Cost
        {
            get => _cost;
            set
            {
                Set(ref _cost, value, nameof(Cost));
            }
        }
        public decimal Discount
        {
            get => _discount;
            set
            {
                Set(ref _discount, Math.Round(value,2), nameof(Discount));
                DisplayingDiscount= (int)((1-Discount)*100);
            }
        }
        public int DisplayingDiscount
        {
            get => _displayingDiscount;
            set
            {
                Set(ref _displayingDiscount, value, nameof(DisplayingDiscount));
            }
        }
        public string SelectedPicture
        {
            get => _selectedPicture == null || _selectedPicture == string.Empty
                ? @"\Resources\Pictures\NonPicture.png" : @$"\Resources\Pictures\{_selectedPicture}";
            set
            {
                Set(ref _selectedPicture, value, nameof(SelectedPicture));
            }
        }
        public List<ProductCategory> ProductCategories { get; }
        

        public ProductPageViewModel(Product product, ProductService entityService, ProductCategoryService productCategoryService)
        {
            if (entityService.GetProduct(product)==null)
            {
                IsNew = true;
            }
            else
            {
                Title= product.Title;
                Description= product.Description;
                SelectedPicture = product.Picture;
                Cost= product.Cost;
                SelectedProductCategory = product.ProductCategory;
            }
            Discount = product.Discount;
            EntityService = entityService;
            ProductCategories = new(productCategoryService.GetProductCategories());
            Product = product;
        }
        public void GetPicturePath(string path)
        {
            SelectedPicture = path.Substring(path.LastIndexOf('\\')+1);
        }
        public void GetProduct() 
        {
            Product.Title = Title;
            Product.Description = Description;
            Product.Discount = Discount;
            Product.Cost= Cost;
            Product.ProductCategory = SelectedProductCategory;
            Product.Picture = SelectedPicture.Substring(SelectedPicture.LastIndexOf('\\') + 1);
        }
    }
}