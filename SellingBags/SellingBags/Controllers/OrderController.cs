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
            OrderContext.GetReloadOrders();
            var ID_Account = Account().ID_Account;
            orderVM.Orders = OrderContext.GetOrders(ID_Account);
            return View(orderVM);
        }
        
        public ActionResult Detail(string ID_Order)
        {
            ViewBag.Status = "";
            ViewBag.Style = "";
            OrderVM orderVM = new OrderVM();
            if (Account() == null)
            {
                return RedirectToAction("Login", "Account");
            }
            orderVM.Order = OrderContext.GetOrder(ID_Order);
            orderVM.OrderDetails = OrderContext.GetOrderDetails(ID_Order);
            orderVM.Shipping = OrderContext.GetShipping(orderVM.Order.ShippingMethod);
            orderVM.Address = OrderContext.GetAddress(orderVM.Order.ID_Address);
            if (orderVM.Order.Status == 0)
                ViewBag.Status = "Chờ xác nhận";
            else if (orderVM.Order.Status == 1)
            {
                ViewBag.Status = "Đang vận chuyển";
                ViewBag.Style = "text-warning";
            }
            else if (orderVM.Order.Status == 2)
            {
                ViewBag.Status = "Đã hoàn thành";
                ViewBag.Style = "text-success";
            }
            else
            {
                ViewBag.Status = "Đã hủy";
                ViewBag.Style = "text-danger";
            }
            
            return View(orderVM);
        }

        [HttpPost]
        public ActionResult CancelOrder(string ID_Order)
        {
            if (ID_Order != null)
            {
                if (OrderContext.IsCancelOrder(ID_Order))
                    return Json(new { result = true, message = "Đơn hàng " + ID_Order + " đã được hủy", url = Url.Action("Index", "Order") });
            }
            return Json(new { result = false, message = "Hủy không thành công"});
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