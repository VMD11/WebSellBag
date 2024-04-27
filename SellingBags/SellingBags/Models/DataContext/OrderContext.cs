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
        private SellingBagsEntities db = null;
        public OrderContext() {
            db = new SellingBagsEntities();
        }

        public void AddBill(OrderVM orderVM, string Id_Account)
        {
            var Customer = GetCustomer(Id_Account);
            var Checkout = new CheckoutContext();
            var PaymentMethod = Checkout.GetPaymentMethod(orderVM.PaymentName);
            var ShippingMethod = Checkout.GetShippingMethod(orderVM.ShippingName);
            if(orderVM.ID_Address == null)
            {
                var address = new Address
                {
                    ID_Address = GenarateRandomID.Execute(),
                    ID_Customer = Customer.ID_Customer,
                    PhoneNumber = orderVM.UserName,
                    FirstName = orderVM.FirstName,
                    LastName = orderVM.LastName,
                    Ward = orderVM.Ward,
                    District = orderVM.District,
                    City = orderVM.City,
                    SpecificAddress = orderVM.SpecificAddress
                };
                db.Addresses.Add(address);
                orderVM.ID_Address = address.ID_Address;
            }
            var order = new Order
            {
                ID_Order = GenarateRandomID.Execute(),
                ID_Customer = Customer.ID_Customer,
                ID_Address = orderVM.ID_Address,
                OrderDate = DateTime.Now,
                Status = 0,
                PaymentMethod = PaymentMethod.Name,
                ShippingMethod = ShippingMethod.Name,
                TotalMoney = orderVM.TotalMoney,
                DeliDate = DateTime.Now.AddDays(ShippingMethod.DeliDate),
            };
            db.Orders.Add(order);
            db.SaveChanges();
            orderVM.ID_Order = order.ID_Order;
        }
        public void AddBillDetail(VirtualCartContext Cart, string ID_Order)
        {
            foreach(var item in Cart.GetList())
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    ID_OrderDetail = GenarateRandomID.Execute(),
                    ID_Order = ID_Order,
                    ID_Product = item.Product.ID_Product,
                    Quantity = item.Quantity,
                    Price = item.Product.Price
                };
                db.OrderDetails.Add(orderDetail);
            }
            db.SaveChanges();
        }
        public IEnumerable<OrderDetail> GetOrderDetails(string ID_Order)
        {
            return db.OrderDetails.Where(o => o.ID_Order == ID_Order);
        }
        public IEnumerable<Order> GetOrders(string ID_Account)
        {
            var ID_Customer = GetCustomer(ID_Account).ID_Customer;
            return db.Orders.Where(o => o.ID_Customer == ID_Customer).OrderByDescending(o => o.OrderDate);
        }
        public Order GetOrder(string ID_Order)
        {
            return db.Orders.Find(ID_Order);
        }
        public Customer GetCustomer(string ID_Account)
        {
            return db.Customers.FirstOrDefault(c => c.ID_Account == ID_Account);
        }
        public Address GetAddress(string ID_Address)
        {
            return db.Addresses.Find(ID_Address);
        }
        
    }
}