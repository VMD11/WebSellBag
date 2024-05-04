using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SellingBags.Models;

namespace SellingBags.Models.ViewModel
{
    public class HomeVM
    {
        public bool IsNew { get; set; }
        public IEnumerable<Product> FeaturedProducts { get; set; }
        public IEnumerable<Category> CategoriesAll { get; set; }
        public  IEnumerable<Brand> BrandsAll { get; set; }
        public IEnumerable<ProductType> ProductTypesAll { get; set; }
    }
}