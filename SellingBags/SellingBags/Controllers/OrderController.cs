using SellingBags.Common;
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
    public class OrderController : Controller
    {
        private readonly CheckoutContext checkoutContext = new CheckoutContext();
        // GET: Order
        public ActionResult Index(OrderVM orderVM)
        {
            ViewBag.Status = "";
            if (Account() == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var ID_Account = Account().ID_Account;
            orderVM.Orders = OrderContext.GetOrders(ID_Account);
            int load = OrderContext.GetReloadOrders();
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
            if (orderVM.Order.Status == 0)
            {
                ViewBag.Status = "Chờ xác nhận";
            }
            else if (orderVM.Order.Status == 1)
            {
                if (orderVM.Order.DeliDate <= DateTime.Now)
                    ViewBag.Status = "Đơn hàng đã hoàn thành";
                else
                    ViewBag.Status = "Đang vận chuyển";
            }
            else
            {
                ViewBag.Status = "Đã hủy";
            }
            return View(orderVM);
        }
        [HttpPost]
        public ActionResult AddBill(OrderVM orderVM)
        {
            if(Account()  == null)
            {
                return RedirectToAction("Login", "Account");
            }
            orderVM.Cart = Cart();
            var ID_Account = Account().ID_Account;
            OrderContext.AddBill(orderVM, ID_Account);
            Session[Sessions.CART] = null;
            
            return RedirectToAction("Detail", "Order",new { ID_Order = orderVM.ID_Order });
        }
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