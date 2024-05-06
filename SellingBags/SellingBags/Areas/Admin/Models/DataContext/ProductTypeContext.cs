using SellingBags.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Areas.Admin.Models.DataContext
{
    public class ProductTypeContext
    {
        private SellingBagsEntities db = null;
        public ProductTypeContext()
        {
            db = new SellingBagsEntities();
        }

        public IEnumerable<ProductType> ProductTypes()
        {
            return db.ProductTypes;
        }
        public IEnumerable<Category> Categories()
        {
            return db.Categories;
        }

        public ProductType GetType(string ID_Type)
        {
            return db.ProductTypes.FirstOrDefault(t => t.ID_Type == ID_Type);
        }

        public Category GetCategory(string ID_Category)
        {
            return db.Categories.FirstOrDefault(c => c.ID_Category == ID_Category);
        }

        
        

        public bool Add(ProductType productType)
        {
            try
            {
                if (ExistType(productType.Name))
                    return false;
                db.ProductTypes.Add(productType);
                db.SaveChanges();
                return true;
            }catch(Exception) { return false; }
        }

        public bool Delete(string ID_Type)
        {
            try
            {
                var query = "delete from Product where ID_Type = '" + ID_Type + "'";
                var query2 = "delete from ProductType where ID_Type = '" + ID_Type + "'";
                db.Database.ExecuteSqlCommand(query);
                db.Database.ExecuteSqlCommand(query2);
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool Update(ProductType productType)
        {
            try
            {
                var Type = db.ProductTypes.FirstOrDefault(t => t.ID_Type == productType.ID_Type);
                if (Type != null)
                {
                    Type.Name = productType.Name;
                    Type.ID_Category = productType.ID_Category;
                    Type.ImageURL = productType.ImageURL;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }catch (Exception) { return false; }
        }

        private bool ExistType(string name)
        {
            return db.ProductTypes.FirstOrDefault(t => t.Name == name) != null;
        }
    }
}