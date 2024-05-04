using SellingBags.Common;
using SellingBags.Models;
using SellingBags.Models.DataContext;
using SellingBags.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
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
        public ActionResult Index()
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
            productVM.NewProducts = productContext.GetNewProducts();
            return View(productVM);
        }

        public ActionResult Search(string keyword)
        {
            productVM.SearchProductsByName = productContext.SearchProductsByName(keyword);
            return View(productVM);
        }

        
        public ActionResult ProductsByBrand(string ID_Brand)
        {
            productVM.ProductsByBrand = productContext.GetProductsByBrand(ID_Brand);
            return View(productVM);
        }

        
        public ActionResult ProductsByType(string ID_ProductType)
        {

            productVM.ProductsByType = productContext.GetProductsByType(ID_ProductType);
            ViewBag.ProductType = productContext.GetProductType(ID_ProductType);
            ViewBag.Category = productContext.GetCategory(ViewBag.ProductType.ID_Category);
            return View(productVM);
        }

        
        public ActionResult ProductsByCategory(string ID_Category)
        {
            
            productVM.ProductsByCategory = productContext.GetProductsByCategory(ID_Category);
            ViewBag.Category = productContext.GetCategory(ID_Category);
            return View(productVM);
        }

        public ActionResult NewProducts()
        {
            productVM.NewProducts = productContext.GetNewProducts();
            return View(productVM);
        }

        public ActionResult BestSeller()
        {
            productVM.BestSellerProducts = productContext.GetBestSellerProducts();
            return View(productVM);
        }
        
    }
}