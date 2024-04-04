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
            return View();
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