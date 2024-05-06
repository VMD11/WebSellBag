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
       
        public static bool AddBill(Address address, Order order, List<OrderDetail> orderDetails)
        {
            try
            {
                if(order == null || orderDetails == null) return false;
                using (var database = new SellingBagsEntities())
                {
                    if(address != null)
                        database.Addresses.Add(address);
                    database.Orders.Add(order);
                    database.OrderDetails.AddRange(orderDetails);
                    database.SaveChanges();
                    return true;
                }

            }catch(Exception) { return false; }
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
            return db.Orders.FirstOrDefault(o => o.ID_Order == ID_Order);
        }
        public static Customer GetCustomer(string ID_Account)
        {
            return db.Customers.FirstOrDefault(c => c.ID_Account == ID_Account);
        }
        public static Address GetAddress(string ID_Address)
        {
            return db.Addresses.FirstOrDefault(a => a.ID_Address == ID_Address);
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