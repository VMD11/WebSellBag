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
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            VirtualCartContext cart = Session[Sessions.CART] as VirtualCartContext;
            if (cart == null)
            {
                cart = new VirtualCartContext();
            }

            Session[Sessions.CART] = cart;
            return View(Session[Sessions.CART] as VirtualCartContext);
        }

        public ActionResult Add(string ID_Product, int Quantity)
        {
            VirtualCartContext cart = Session[Sessions.CART] as VirtualCartContext;
            if (cart == null)
            {
                cart = new VirtualCartContext();
            }
            cart.AddProduct(ID_Product, Quantity);
            Session[Sessions.CART] = cart;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(string ID_Product, int Quantity)
        {
            VirtualCartContext cart = Session[Sessions.CART] as VirtualCartContext;
            
            cart.UpdateProduct(ID_Product, Quantity);
            Session[Sessions.CART] = cart;
            
            return Json(new { TotalMoney = cart.TotalMoney(), TotalQuantity = cart.TotaQuantity() });
        }

        public ActionResult Delete(string ID_Product)
        {
            VirtualCartContext cart = Session[Sessions.CART] as VirtualCartContext;
            cart.DeleteProduct(ID_Product);
            Session[Sessions.CART] = cart;

            return RedirectToAction("Index");
        }

        public ActionResult Checkout()
        {
            CheckoutVM checkoutVM = new CheckoutVM();
            CheckoutContext checkoutContext = new CheckoutContext();
            checkoutVM.Cart = Session[Sessions.CART] as VirtualCartContext;
            checkoutVM.Shippings = checkoutContext.GetShippings();
            checkoutVM.Payments = checkoutContext.GetPayments();
            return View(checkoutVM);
        }

        [HttpPost]
        public ActionResult AddBill(OrderVM orderVM)
        {
            try { 
                var ID_Account = Account().ID_Account;
                var Customer = OrderContext.GetCustomer(ID_Account);
                var Shipping = OrderContext.GetShipping(orderVM.ShippingName);
                Address address = null; 
                if (orderVM.ID_Address == null)
                {
                    address = new Address()
                    {
                        ID_Address = GenarateRandomID.Execute(),
                        ID_Customer = Customer.ID_Customer,
                        PhoneNumber = orderVM.UserName,
                        FirstName = orderVM.FirstName,
                        LastName = orderVM.LastName,
                        Ward = orderVM.Ward,
                        District = orderVM.District,
                        City = orderVM.City,
                        SpecificAddress = orderVM.SpecificAddress,
                    };
                    
                }
                var order = new Order()
                {
                    ID_Order = GenarateRandomID.Execute(),
                    ID_Customer = Customer.ID_Customer,
                    ID_Address = address?.ID_Address ?? orderVM.ID_Address,
                    OrderDate = DateTime.Now,
                    Status = 0,
                    PaymentMethod = orderVM.PaymentName,
                    ShippingMethod = orderVM.ShippingName,
                    TotalMoney = orderVM.TotalMoney,
                    DeliDate = DateTime.Now.AddDays((double)Shipping.DeliDate),
                };
                var orderDetails = new List<OrderDetail>();
                foreach (var item in Cart().GetList())
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
                    return Json( new {result = true});
                }
                return Json( new {result = false});
            }catch (Exception ex) {
                return Json(new { result = false, message = ex.Message });
            }
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