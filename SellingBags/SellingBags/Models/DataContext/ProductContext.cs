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
            return db.Products.FirstOrDefault( p => p.ID_Product == ID_Product);
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

        public string GetBrandName(string ID_Product)
        {
            var ID_Brand = GetProduct(ID_Product).ID_Brand;
            return db.Brands.FirstOrDefault(b => b.ID_Brand == ID_Brand).Name;
        }

        public string GetTypeName(string ID_Product)
        {
            var ID_Type = GetProduct(ID_Product).ID_Type;
            return db.ProductTypes.FirstOrDefault(p => p.ID_Type == ID_Type).Name;
        }

        public string GetCategoryName(string ID_Product)
        {
            var ID_Category = GetProductType(GetProduct(ID_Product).ID_Type).ID_Category;
            return db.Categories.FirstOrDefault(c => ID_Category == c.ID_Category).Name;
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
        public Brand GetBrand(string ID_Brand)
        {
            return db.Brands.FirstOrDefault(b => b.ID_Brand == ID_Brand);
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
            if(products.Count < 12)
            {

                foreach (var product in db.Products.OrderByDescending(p => p.DateCreated.Value))
                {
                    if(products.FirstOrDefault(p => p.ID_Product == product.ID_Product) == null)
                        products.Add(product);
                    if (products.Count == 12)
                        break;

                }
            }
            return products.OrderByDescending(p => p.DateCreated);
        }

        public IEnumerable<Product> GetBestSellerProducts()
        {
            var products = new List<Product>();
            foreach(var item in db.spBestSeller(DateTime.Now.Month))
            {
                products.Add(GetProduct(item.ID_Product));
            }
            return products;
        }

        public class QuantitySold
        {
            public string ID_Product { get; set; }
            public int? Quantity { get; set; }
        }
        public IEnumerable<QuantitySold> GetQuantitySold()
        {
            var query = from o in db.OrderDetails
                        group o by o.ID_Product into groups
                        select new QuantitySold
                        {
                            ID_Product = groups.Key,
                            Quantity = groups.Sum(q => q.Quantity)
                        };
            return query;            
        }


        private bool IsNew(Product product)
        {
            return db.spNewProduct().FirstOrDefault(p => p.ID_Product == product.ID_Product) != null;
        }

        private bool IsBestSeller(Product product)
        {
            return db.spBestSeller(DateTime.Now.Month).FirstOrDefault(p => p.ID_Product == product.ID_Product) != null;
        }
    }
}