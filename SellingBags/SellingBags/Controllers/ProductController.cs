using SellingBags.Models;
using SellingBags.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellingBags.Controllers
{
    public class ProductController : Controller
    {
        private readonly SellingBagsEntities db = new SellingBagsEntities();
        // GET: Product
        public ActionResult Product()
        {
            ProductVM productVM = new ProductVM();
            productVM.Brands = db.Brands;
            productVM.Products = db.Products;
            productVM.ProductTypes = db.ProductTypes;
            return View(productVM);
        }

        public ActionResult Detail(string ID_Product)
        {
            var product = db.Products.FirstOrDefault(p => p.ID_Product.Equals(ID_Product));
            return View(product);
        }

        public ActionResult WishList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductsByBrand(string ID_Brand)
        {
            var products = db.Products.Where(p => p.ID_Brand.Equals(ID_Brand)).ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult ProductsByType(string ID_ProductType)
        {
            if(!ID_ProductType.Contains("C"))
            {
                var products = db.Products.Where(p => p.ID_Type.Equals(ID_ProductType)).ToList();
                return View(products);
            }
            else
            {
                //var products = db.spProductsByType(ID_ProductType).ToList();
                var products = db.Database.SqlQuery<Product>("exec spProductsByType @ID_Category", new SqlParameter("ID_Category", ID_ProductType)).ToList();

                return View(products);
            }
        }
    }
}