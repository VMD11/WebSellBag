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

        public IEnumerable<Product> GetProductsAll()
        {
            return db.Products;
        }

    }
}