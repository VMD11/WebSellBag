using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SellingBags.Models;

namespace SellingBags.Models.ViewModel
{
    public class HomeVM
    {
        public IEnumerable<Product> ProductsAll { get; set; }
        public IEnumerable<Category> CategoriesAll { get; set; }
        public  IEnumerable<Brand> BrandsAll { get; set; }
        public IEnumerable<ProductType> ProductTypesAll { get; set; }
    }
}