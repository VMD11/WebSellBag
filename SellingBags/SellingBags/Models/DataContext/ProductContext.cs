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

        public Product GetProduct(string ID_Product)
        {
            return db.Products.Find(ID_Product);
        }

        public IEnumerable<Product> GetProductsAll()
        {
            return db.Products.ToList();
        }

        public IEnumerable<Product> GetRelatedProductsList(string ID_Product)
        {
            var results = new List<Product>();
            var ID_Brand = GetProduct(ID_Product).ID_Brand;
            var ProductsList = from p in db.Products
                               where p.ID_Brand == ID_Brand
                               orderby p.ID_Product
                               select p;
            foreach (var product in ProductsList)
            {
                results.Add(product);
            }
            results.Remove(GetProduct(ID_Product));
            return results;
        }

        public IEnumerable<Product> SearchProductsByName(string KeyName)
        {
            return db.Products.Where(p => p.Name.Contains(KeyName));
        }

        public string GetBrand(string ID_Product)
        {
            var ID_Brand = GetProduct(ID_Product).ID_Brand;
            return db.Brands.Find(ID_Brand).Name;
        }

        public string GetType(string ID_Product)
        {
            var ID_Type = GetProduct(ID_Product).ID_Type;
            return db.ProductTypes.Find(ID_Type).Name;
        }

        public IEnumerable<Product> GetProductsByType(string ID_ProductType)
        {
            return db.Products.Where(p => p.ID_Type == ID_ProductType);
        }
        public IEnumerable<Product> GetProductsByBrand(string ID_Brand)
        {
            return db.Products.Where(p => p.ID_Brand == ID_Brand);
        }
        public IEnumerable<Product> GetProductsByCategory(string ID_Category)
        {
            return  (from product in db.Products
                     join type in db.ProductTypes on product.ID_Type equals type.ID_Type
                     where type.ID_Category == ID_Category
                     select product).ToList();
             
        }

        public Category GetCategory(string ID_Category)
        {
            return db.Categories.FirstOrDefault(c => c.ID_Category == ID_Category);
        }
        public ProductType GetProductType(string ID_Type)
        {
            return db.ProductTypes.FirstOrDefault(p => p.ID_Type == ID_Type);
        }
        
        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public IEnumerable<ProductType> GetProductTypes(string ID_Category)
        {
            return db.ProductTypes.Where(p => p.ID_Category == ID_Category);
        }
        public bool IsWishListed(string ID_Account, string ID_Product)
        {
            var result = db.WishLists.FirstOrDefault(r => r.ID_Account == ID_Account && r.ID_Product == ID_Product);
            return result != null;
        }

        public IEnumerable<Product> GetNewProducts()
        {
            var products = new List<Product>();
            foreach(var product in db.Products)
            {
                if(IsNew(product))
                    products.Add(product);
            }
            return products;
        }

        private bool IsNew(Product product)
        {
            if(!product.DateCreated.HasValue)
                return false;

            var sinceCreate = DateTime.Now - product.DateCreated.Value;
            if(sinceCreate.TotalDays <= 20)
            {
                return true;
            }
            return false;
        }
    }
}