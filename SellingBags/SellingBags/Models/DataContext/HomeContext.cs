using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.DataContext
{
    public class HomeContext
    {
        private SellingBagsEntities db;
        public HomeContext()
        {
            db = new SellingBagsEntities();
        }
        public IEnumerable<Brand> GetBrandsAll()
        {
            return db.Brands;
        }
        public IEnumerable<ProductType> GetProductTypesAll()
        {
            return db.ProductTypes;
        }

        public IEnumerable<Product> GetFeaturedProducts()
        {
            var products = new List<Product>();
            foreach (var item in db.spBestSeller(DateTime.Now.Month))
            {
                products.Add(GetProduct(item.ID_Product));
                
            }
            foreach (var item in db.spNewProduct())
            {
                if (IsBestSeller(GetProduct(item.ID_Product)))
                    continue;
                products.Add(GetProduct(item.ID_Product));
                
            }
            return products;
        }

        public IEnumerable<Category> GetCategoriesAll()
        {
            return db.Categories;
        }

        public bool IsBestSeller(Product product)
        {
            return db.spBestSeller(DateTime.Now.Month).FirstOrDefault(p => p.ID_Product == product.ID_Product) != null;
        }

        public bool IsNew(Product product)
        {
            return db.spNewProduct().FirstOrDefault(p => p.ID_Product == product.ID_Product) != null;
        }

        private Product GetProduct(string ID_Product)
        {
            return db.Products.FirstOrDefault(p => p.ID_Product == ID_Product);
        }
    }
}