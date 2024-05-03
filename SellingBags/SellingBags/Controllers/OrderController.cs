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
            var ID_Account = Account().ID_Account;
            var Customer = OrderContext.GetCustomer(ID_Account);
            var Shipping = OrderContext.GetShipping(orderVM.ShippingName);
            var address = new Address();
            if (orderVM.ID_Address == null)
            {
                address.ID_Address = GenarateRandomID.Execute();
                address.ID_Customer = Customer.ID_Customer;
                address.PhoneNumber = orderVM.UserName;
                address.FirstName = orderVM.FirstName;
                address.LastName = orderVM.LastName;
                address.Ward = orderVM.Ward;
                address.District = orderVM.District;
                address.City = orderVM.City;
                address.SpecificAddress = orderVM.SpecificAddress;
            }
            var order = new Order()
            {
                ID_Order = GenarateRandomID.Execute(),
                ID_Customer = Customer.ID_Customer,
                ID_Address = orderVM.ID_Address == null ? address.ID_Address : orderVM.ID_Address,
                OrderDate = DateTime.Now,
                Status = 0,
                PaymentMethod = orderVM.PaymentName,
                ShippingMethod = Shipping.Name,
                TotalMoney = orderVM.TotalMoney,
                DeliDate = DateTime.Now.AddDays((double)Shipping.DeliDate),
            };
            orderVM.Cart = Cart();
            var orderDetails = new List<OrderDetail>();
            foreach (var item in orderVM.Cart.GetList())
            {
                var orderDetail = new OrderDetail()
                {
                    ID_OrderDetail = GenarateRandomID.Execute(),
                    ID_Order = order.ID_Order,
                    ID_Product = item.Product.ID_Product,
                    Quantity = item.Quantity,
                    Price = item.Product.Price,
                };
                orderDetails.Add(orderDetail);
            }
            if(OrderContext.AddBill(address, order, orderDetails))
            {
                Session[Sessions.CART] = null;
                return RedirectToAction("Index", "Order");
            }
            return RedirectToAction("Checkout", "Cart");
            
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