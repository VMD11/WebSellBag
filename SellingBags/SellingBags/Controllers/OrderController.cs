using SellingBags.Common;
using SellingBags.Models;
using SellingBags.Models.DataContext;
using SellingBags.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SellingBags.Controllers
{
    public class OrderController : Controller
    {
        //private readonly CheckoutContext checkoutContext = new CheckoutContext();
        // GET: Order
        public ActionResult Index()
        {
            ViewBag.Status = "";
            if (Account() == null)
            {
                return RedirectToAction("Login", "Account");
            }
            OrderVM orderVM = new OrderVM();
            int load = OrderContext.GetReloadOrders();
            var ID_Account = Account().ID_Account;
            orderVM.Orders = OrderContext.GetOrders(ID_Account);
            return View(orderVM);
        }

        
        public ActionResult Detail(string ID_Order)
        {
            ViewBag.Status = "";
            OrderVM orderVM = new OrderVM();
            if (Account() == null)
            {
                return RedirectToAction("Login", "Account");
            }
            orderVM.Order = OrderContext.GetOrder(ID_Order);
            orderVM.OrderDetails = OrderContext.GetOrderDetails(ID_Order);
            orderVM.Shipping = OrderContext.GetShipping(orderVM.Order.ShippingMethod);
            orderVM.Address = OrderContext.GetAddress(orderVM.Order.ID_Address);
            if (orderVM.Order.Status == 0) ViewBag.Status = "Chờ xác nhận";
            else if (orderVM.Order.Status == 1) ViewBag.Status = "Đang vận chuyển";
            else if(orderVM.Order.Status == 2) ViewBag.Status = "Đơn hàng đã hoàn thành";
            else ViewBag.Status = "Đã hủy";
            
            return View(orderVM);
        }

        //[HttpPost]
        
        private LoginAccount Account()
        {
            return Session[Sessions.USER_SESSION] as LoginAccount;
        }
        private VirtualCartContext Cart()
        {
            return Session[Sessions.CART] as VirtualCartContext;
        }
    }
}