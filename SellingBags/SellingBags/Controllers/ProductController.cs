using Microsoft.Ajax.Utilities;
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
            productVM.Brand = productContext.GetBrandName(ID_Product);
            productVM.Type = productContext.GetTypeName(ID_Product);
            productVM.RelativeProductsList = productContext.GetRelatedProductsList(ID_Product);
            productVM.NewProducts = productContext.GetNewProducts();
            productVM.QuantitySold = productContext.GetQuantitySold();
            return View(productVM);
        }

        public ActionResult Search(string keyword)
        {
            productVM.SearchProductsByName = productContext.SearchProductsByName(keyword);
            productVM.Colors = productContext.GetColors();
            ViewBag.Key = keyword;
            return View(productVM);
        }


        public ActionResult ProductsByBrand(string ID_Brand)
        {
            productVM.ProductsByBrand = productContext.GetProductsByBrand(ID_Brand);
            productVM.Colors = productContext.GetColors();
            ViewBag.Brand = productContext.GetBrand(ID_Brand);
            return View(productVM);
        }

        public ActionResult ProductsByType(string ID_ProductType)
        {

            productVM.ProductsByType = productContext.GetProductsByType(ID_ProductType);
            productVM.Colors = productContext.GetColors();
            ViewBag.ProductType = productContext.GetProductType(ID_ProductType);
            ViewBag.Category = productContext.GetCategory(ViewBag.ProductType.ID_Category);
            return View(productVM);
        }

        
        public ActionResult ProductsByCategory(string ID_Category)
        {
            
            productVM.ProductsByCategory = productContext.GetProductsByCategory(ID_Category);
            productVM.Colors = productContext.GetColors();
            ViewBag.Category = productContext.GetCategory(ID_Category);
            
            return View(productVM);
        }

        public ActionResult NewProducts()
        {
            productVM.NewProducts = productContext.GetNewProducts();
            productVM.Colors = productContext.GetColors();
            return View(productVM);
        }

        public ActionResult BestSeller()
        {
            productVM.BestSellerProducts = productContext.GetBestSellerProducts();
            productVM.Colors = productContext.GetColors();
            return View(productVM);
        }
                
        
        public ActionResult FilterNewProducts(string price, string color, string sort)
        {
            productVM.NewProducts = productContext.GetFilterProduct(productContext.GetNewProducts(), price, color, sort);
            return PartialView("_ProductsPartial", productVM.NewProducts);
        }

        public ActionResult FilterBestSellerProducts(string price, string color, string sort)
        {
            productVM.BestSellerProducts = productContext.GetFilterProduct(productContext.GetBestSellerProducts(), price, color, sort);
            return PartialView("_ProductsPartial", productVM.BestSellerProducts);
        }

        public ActionResult FilterProductsByType(string id, string price, string color, string sort)
        {
            productVM.ProductsByType = productContext.GetFilterProduct(productContext.GetProductsByType(id), price, color, sort);
            return PartialView("_ProductsPartial", productVM.ProductsByType);
        }
        public ActionResult FilterProductsByCategory(string id, string price, string color, string sort)
        {
            productVM.ProductsByCategory = productContext.GetFilterProduct(productContext.GetProductsByCategory(id), price, color, sort);
            return PartialView("_ProductsPartial", productVM.ProductsByCategory);
        }
        public ActionResult FilterProductsBySearch(string id, string price, string color, string sort)
        {
            productVM.SearchProductsByName = productContext.GetFilterProduct(productContext.SearchProductsByName(id), price, color, sort);
            return PartialView("_ProductsPartial", productVM.SearchProductsByName);
        }


    }
}