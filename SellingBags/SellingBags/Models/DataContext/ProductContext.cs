using SellingBags.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.DataContext
{
    public class ProductContext
    {
        private SellingBagsEntities db;

        public ProductContext()
        {
            db = new SellingBagsEntities();
        }

        public Product Find(string ID_Product)
        {
            return db.Products.Find(ID_Product);
        }

        public List<ProductVM> RelatedProductList(string ID_Brand) {
            return null;
        }
    }
}