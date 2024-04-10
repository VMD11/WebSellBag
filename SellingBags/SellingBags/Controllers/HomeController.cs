using SellingBags.Models;
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
        public ActionResult Index()
        {
            SellingBagsEntities db = new SellingBagsEntities();
            HomeVM homeVM = new HomeVM();
            homeVM.Brands = db.Brands.ToList();
            homeVM.ProductTypes = db.ProductTypes;


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