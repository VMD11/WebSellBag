using SellingBags.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SellingBags.Areas.Admin.Models.DataContext
{
    public class ProductContext
    {
        private SellingBagsEntities db = null;
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
            return (from product in db.Products
                    join type in db.ProductTypes on product.ID_Type equals type.ID_Type
                    where type.ID_Category == ID_Category
                    select product).ToList();

        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }
        public IEnumerable<Brand> GetBrands()
        {
            return db.Brands.ToList();
        }
        public IEnumerable<ProductType> GetProductTypes()
        {
            return db.ProductTypes.ToList();
        }

        public IEnumerable<ProductType> GetProductTypes(string ID_Category)
        {
            return db.ProductTypes.Where(p => p.ID_Category == ID_Category);
        }

        public bool Add(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }catch (Exception)
            {
                return false;
            }
        }

        

        public bool Delete(string ID_Product)
        {
            try
            {
                var query1 = "delete from Discount where ID_Product = '" + ID_Product + "'";
                var query2 = "delete from Cart where ID_Product = '" + ID_Product + "'";
                var query3 = "delete from WishList where ID_Product = '" + ID_Product + "'";
                var query4 = "delete from OrderDetail where ID_Product = '" + ID_Product + "'";
                var query5 = "delete from Product where ID_Product = '" + ID_Product + "'";
                db.Database.ExecuteSqlCommand(query1);
                db.Database.ExecuteSqlCommand(query2);
                db.Database.ExecuteSqlCommand(query3);
                db.Database.ExecuteSqlCommand(query4);
                db.Database.ExecuteSqlCommand(query5);
                return true;
            }catch (Exception)
            {
                return false;
            }
            
        }
        public bool Update(Product newProduct)
        {
            try
            {
                var product = db.Products.FirstOrDefault(p => p.ID_Product == newProduct.ID_Product);
                if (product != null)
                {
                    product.Name = newProduct.Name;
                    product.Color = newProduct.Color;
                    product.Size = newProduct.Size;
                    product.Price = newProduct.Price;
                    product.Description = newProduct.Description;
                    product.ID_Type = newProduct.ID_Type;
                    product.ID_Brand = newProduct.ID_Brand;

                }
                db.SaveChanges();
                return true;
            }catch (Exception) { return false; }
        }
    }
}