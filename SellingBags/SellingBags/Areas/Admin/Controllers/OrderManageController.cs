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
        private readonly OrderVM orderVM = new OrderVM();
        private readonly OrderContext orderContext = new OrderContext();
        // GET: Admin/OrderManage
        public ActionResult Index()
        {
            if (!accountSession())
            {
                return RedirectToAction("Index", "Login");
            }
            orderVM.Orders = orderContext.GetOrders();
            orderContext.GetReLoadOrders();
            return View(orderVM);
        }
        public ActionResult FilterOrders(string sort)
        {
            orderVM.Orders = orderContext.GetFilterOrders(sort);
            return PartialView("_OrdersPartial",orderVM.Orders);
        }

        public ActionResult Detail(string ID_Order)
        {
            if (!accountSession())
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.DeliDate = "";
            orderVM.Order = orderContext.GetOrderById(ID_Order);
            orderVM.Address = orderContext.GetAddressByID(orderVM.Order.ID_Address);
            orderVM.OrderDetails = orderContext.GetOrderDetails(ID_Order);
            orderVM.Shipping = orderContext.GetShippingByID(ID_Order);
            if(orderVM.Order.Status == 2)
            {
                ViewBag.DeliDate = "Ngày giao hàng: " + Converts.convertDate(orderVM.Order.DeliDate);
            }
            return View(orderVM);
        }


        public ActionResult Confirm(string ID_Order)
        {
            if(orderContext.ConfirmOrder(ID_Order))
            {
                return RedirectToAction("Index", "OrderManage");
            }
            return RedirectToAction("Index", "OrderManage");
        }
        public ActionResult Cancel(string ID_Order)
        {
            if(orderContext.CancelOrder(ID_Order))
            {
                return RedirectToAction("Index", "OrderManage");
            }
            return RedirectToAction("Index", "OrderManage");
        }
        private bool accountSession()
        {
            return Session[Sessions.ADMIN_SESSION] != null;
        }
    }
}