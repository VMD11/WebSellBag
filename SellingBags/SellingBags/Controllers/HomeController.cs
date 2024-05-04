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
            homeVM.CategoriesAll = homeContext.GetCategoriesAll();
            homeVM.BrandsAll = homeContext.GetBrandsAll();
            homeVM.ProductTypesAll = homeContext.GetProductTypesAll();
            homeVM.FeaturedProducts = homeContext.GetFeaturedProducts();
            return View(homeVM);
        }

    }
}