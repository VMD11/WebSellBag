﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.ViewModel
{
    public class ProductVM
    {
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}