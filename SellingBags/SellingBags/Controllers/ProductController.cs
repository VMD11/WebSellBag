using SellingBags.Models;
using SellingBags.Models.DataContext;
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
        private readonly ProductVM productVM = new ProductVM();
        private readonly ProductContext productContext = new ProductContext();
        // GET: Product
        public ActionResult Product()
        {
            productVM.ProductsAll = productContext.GetProductsAll();
            return View(productVM);
        }

        public ActionResult Detail(string ID_Product)
        {
            productVM.Product = productContext.GetProduct(ID_Product);
            productVM.Brand = productContext.GetBrand(ID_Product);
            productVM.Type = productContext.GetBrand(ID_Product);
            productVM.RelativeProductsList = productContext.GetRelatedProductsList(ID_Product);
            return View(productVM);
        }

        public ActionResult WishList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductsByBrand(string ID_Brand)
        {
            productVM.ProductsByBrand = productContext.GetProductsByBrand(ID_Brand);
            return View(productVM);
        }

        [HttpGet]
        public ActionResult ProductsByType(string ID_ProductType)
        {
            
            productVM.ProductsByType = productContext.GetProductsByType(ID_ProductType);
            return View(productVM);
        }
    }
}