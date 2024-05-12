using SellingBags.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.ViewModel
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int Discount { get; set; }
        public IEnumerable<Product> ProductsAll { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Category> Categories {  get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }
        public IEnumerable<Product> ProductsByType { get; set; }
        public IEnumerable<Product> ProductsByBrand { get; set; }
        public IEnumerable<Product> ProductsByCategory { get; set; }
        public IEnumerable<Product> SearchProductsByName { get; set; }
        public IEnumerable<Product> RelativeProductsList { get; set; }
        public IEnumerable<Product> WishList { get; set; }
        public IEnumerable<Product> NewProducts { get; set; }
        public IEnumerable<Product> BestSellerProducts { get; set; }
        public IEnumerable<ProductContext.QuantitySold> QuantitySold { get; set; }
        public IEnumerable<string> Colors { get; set; }
    }
}