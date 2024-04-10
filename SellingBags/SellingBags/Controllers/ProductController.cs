using SellingBags.Models;
using SellingBags.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellingBags.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Product()
        {
            SellingBagsEntities db = new SellingBagsEntities();
            ProductVM productVM = new ProductVM();
            productVM.Brands = db.Brands;
            productVM.Products = db.Products;
            productVM.ProductTypes = db.ProductTypes;
            return View(productVM);
        }

        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult WishList()
        {
            return View();
        }
    }
}