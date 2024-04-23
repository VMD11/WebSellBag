using SellingBags.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Areas.Admin.Models.DataContext
{
    public class BrandContext
    {
        private SellingBagsEntities db = null;
        public BrandContext() 
        {
            db = new SellingBagsEntities();        
        }

        public IEnumerable<Brand> Brands()
        {
            return db.Brands;
        }

       


        public bool Add(Brand brand)
        {
            try
            {
                if (ExistBrand(brand.Name))
                    return false;
                db.Brands.Add(brand);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool Delete(string ID_Brand)
        {
            try
            {
                var query = "delete from Product where ID_Brand = '" + ID_Brand + "'";
                var query2 = "delete from Brand where ID_Brand = '" + ID_Brand + "'";
                db.Database.ExecuteSqlCommand(query);
                db.Database.ExecuteSqlCommand(query2);
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool Update(Brand newBrand)
        {
            try
            {
                var brand = db.Brands.FirstOrDefault(t => t.ID_Brand == newBrand.ID_Brand);
                if (brand != null)
                {
                    brand.Name = newBrand.Name;
                    brand.ImageURL = newBrand.ImageURL;

                }
                db.SaveChanges();
                return true;

            }
            catch (Exception) { return false; }
        }

        private bool ExistBrand(string name)
        {
            return db.Brands.FirstOrDefault(b => b.Name == name) != null;
        }
    }
}