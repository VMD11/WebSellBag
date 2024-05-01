using SellingBags.Common;
using SellingBags.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.DataContext
{
    public class OrderContext
    {
        private static SellingBagsEntities db = new SellingBagsEntities();
       
        public static void AddBill(OrderVM orderVM, string Id_Account)
        {
            var Customer = GetCustomer(Id_Account);
            var Shipping = GetShipping(orderVM.ShippingName);
            var address = new Address();
            if(orderVM.ID_Address == null)
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
                db.Addresses.Add(address);
            }
            var order = new Order() {
                ID_Order = GenarateRandomID.Execute(),
                ID_Customer = Customer.ID_Customer,
                ID_Address = orderVM.ID_Address == null ? address.ID_Address : orderVM.ID_Address,
                OrderDate = DateTime.Now,
                Status = 0,
                PaymentMethod = orderVM.PaymentName,
                ShippingMethod = orderVM.ShippingName,
                TotalMoney = orderVM.TotalMoney,
                DeliDate = DateTime.Now.AddDays((double)Shipping.DeliDate),
            
            };
            db.Orders.Add(order);
            foreach(var item in orderVM.Cart.GetList())
            {
                var orderDetail = new OrderDetail();
                orderDetail.ID_OrderDetail = GenarateRandomID.Execute();
                orderDetail.ID_Order = order.ID_Order;
                orderDetail.ID_Product = item.Product.ID_Product;
                orderDetail.Quantity = item.Quantity;
                orderDetail.Price = item.Product.Price;
                db.OrderDetails.Add(orderDetail);
            }
            db.SaveChanges();
            orderVM.ID_Order = order.ID_Order;
            
        }
        
        public static IEnumerable<OrderDetail> GetOrderDetails(string ID_Order)
        {
            return db.OrderDetails.Where(o => o.ID_Order == ID_Order);
        }
        public static IEnumerable<Order> GetOrders(string ID_Account)
        {
            var ID_Customer = GetCustomer(ID_Account).ID_Customer;
            return db.Orders.Where(o => o.ID_Customer == ID_Customer).OrderByDescending(o => o.OrderDate);
        }
        public static Order GetOrder(string ID_Order)
        {
            return db.Orders.Find(ID_Order);
        }
        public static Customer GetCustomer(string ID_Account)
        {
            return db.Customers.FirstOrDefault(c => c.ID_Account == ID_Account);
        }
        public static Address GetAddress(string ID_Address)
        {
            return db.Addresses.Find(ID_Address);
        }
        public Payment GetPayment(string Name)
        {
            return db.Payments.FirstOrDefault(m => m.Name == Name);
        }
        public static Shipping GetShipping(string Name)
        {
            return db.Shippings.FirstOrDefault(m => m.Name == Name);
        }
        public static int GetReloadOrders()
        {
            return db.ReloadOrders();
        }
    }
}