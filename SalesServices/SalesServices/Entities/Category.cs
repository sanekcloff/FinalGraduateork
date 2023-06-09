﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesServices.Entities
{
    public class Category
    {
        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public ICollection<ProductCategory> ProductCategories { get; set; } = null!;
    }
}
