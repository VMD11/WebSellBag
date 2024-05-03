using SellingBags.Areas.Admin.Models.DataContext;
using SellingBags.Areas.Admin.Models.ViewModel;
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
        private readonly DashboardContext dashboardContext = new DashboardContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var account = Session[Sessions.ADMIN_SESSION] as LoginAccount;
            if (account == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var dashboardVM = new DashboardVM();
            dashboardVM.DaylyRevenue = dashboardContext.GetDaylyRevenue();
            dashboardVM.MonthlyRevenue = dashboardContext.GetMonthlyRevenue();
            dashboardVM.YearlyRevenue = dashboardContext.GetYearlyRevenue();
            ViewBag.RevenuePerMonth = dashboardContext.GetRevenuePerMonth();
            return View(dashboardVM);
        }

        public ActionResult Logout()
        {
            Session[Sessions.ADMIN_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}