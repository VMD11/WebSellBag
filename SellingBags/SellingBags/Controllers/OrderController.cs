using SellingBags.Common;
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
        private OrderContext orderContext = new OrderContext();
        private CheckoutContext checkoutContext = new CheckoutContext();
        // GET: Order
        public ActionResult Index(OrderVM orderVM)
        {
            ViewBag.Status = "";
            if (Account() == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var ID_Account = Account().ID_Account;
            orderVM.Orders = orderContext.GetOrders(ID_Account);
            return View(orderVM);
        }

        [HttpGet]
        public ActionResult Detail(string ID_Order)
        {
            ViewBag.Status = "";
            OrderVM orderVM = new OrderVM();
            if (Account() == null)
            {
                return RedirectToAction("Login", "Account");
            }
            orderVM.Order = orderContext.GetOrder(ID_Order);
            if (orderVM.Order.DeliDate <= DateTime.Now)
            {
                ViewBag.Status = "Đơn hàng hoàn tất";
            }
            else
            {
                ViewBag.Status = "Đang vận chuyển";
            }
            orderVM.OrderDetails = orderContext.GetOrderDetails(ID_Order);
            orderVM.ShippingMethod = checkoutContext.GetShippingMethod(orderVM.Order.ShippingMethod);
            orderVM.ID_Address = orderVM.Order.ID_Address;
            orderVM.Address = orderContext.GetAddress(orderVM.ID_Address);
            return View(orderVM);
        }

        [HttpPost]
        public ActionResult Detail(OrderVM orderVM)
        {
            ViewBag.Status = "";
            if (Account() == null)
            {
                return RedirectToAction("Login", "Account");
            }
            orderVM.Order = orderContext.GetOrder(orderVM.ID_Order);
            if (orderVM.Order.Status == 1)
            {
                ViewBag.Status = "Đơn hàng hoàn tất";
            }
            ViewBag.Status = "Đang vận chuyển";
            orderVM.OrderDetails = orderContext.GetOrderDetails(orderVM.ID_Order);
            orderVM.Address = orderContext.GetAddress(orderVM.ID_Address);
            return View(orderVM);
        }
        public ActionResult Add(OrderVM orderVM)
        {
            if(Account()  == null)
            {
                return RedirectToAction("Login", "Account");
            }
            orderVM.Cart = Cart();
            var ID_Account = Account().ID_Account;
            orderContext.AddBill(orderVM, ID_Account);
            orderContext.AddBillDetail(orderVM.Cart, orderVM.ID_Order);
            Session[Sessions.CART] = null;
            return RedirectToAction("Detail",orderVM);
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