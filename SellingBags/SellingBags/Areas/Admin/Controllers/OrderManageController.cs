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
    public class OrderManageController : Controller
    {
        private readonly OrderContext orderContext = new OrderContext();
        // GET: Admin/OrderManage
        public ActionResult Index()
        {
            if (!accountSession())
            {
                return RedirectToAction("Index", "Login");
            }
            var orderVM = new OrderVM();
            orderVM.Addresses = orderContext.GetAddresses();
            orderVM.Orders = orderContext.GetOrders();
            return View(orderVM);
        }

        public ActionResult Detail(string ID_Order)
        {
            if (!accountSession())
            {
                return RedirectToAction("Index", "Login");
            }
            var orderVM = new OrderVM();
            orderVM.Order = orderContext.GetOrderById(ID_Order);
            orderVM.Address = orderContext.GetAddressByID(orderVM.Order.ID_Address);
            orderVM.OrderDetails = orderContext.GetOrderDetails(ID_Order);
            return View(orderVM);
        }

        private bool accountSession()
        {
            return Session[Sessions.ADMIN_SESSION] != null;
        }
    }
}