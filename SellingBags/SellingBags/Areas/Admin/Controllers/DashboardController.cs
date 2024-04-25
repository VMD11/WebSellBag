using SellingBags.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellingBags.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var account = Session[Sessions.ADMIN_SESSION] as LoginAccount;
            if (account == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session[Sessions.ADMIN_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}