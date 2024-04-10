using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SellingBags.Models;

namespace SellingBags.Models.ViewModel
{
    public class HomeVM
    {
        public  IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }
    }
}