using SellingBags.Models;
using SellingBags.Models.DataContext;
using SellingBags.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SellingBags.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeVM homeVM = new HomeVM();
        private readonly HomeContext homeContext = new HomeContext();
        public ActionResult Index()
        {
            homeVM.BrandsAll = homeContext.GetBrandsAll();
            homeVM.ProductTypesAll = homeContext.GetProductTypesAll();
            homeVM.ProductsAll = homeContext.GetProductsAll();
            return View(homeVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}