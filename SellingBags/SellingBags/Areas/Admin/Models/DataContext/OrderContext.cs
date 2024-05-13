using SellingBags.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Areas.Admin.Models.DataContext
{
    public class OrderContext
    {
        private SellingBagsEntities db = null;
        public OrderContext()
        {
            db = new SellingBagsEntities();
        }
        public IEnumerable<Address> GetAddresses()
        {
            return db.Addresses;
        }
        public Address GetAddressByID(string ID_Address)
        {
            return db.Addresses.FirstOrDefault(a => a.ID_Address == ID_Address);
        }
        public IEnumerable<Order> GetOrders()
        {
            return db.Orders.OrderByDescending(o => o.OrderDate);
        }
        public IEnumerable<Order> GetFilterOrders(string sort)
        {
            var orders = GetOrders();
            switch (sort)
            {
                case "wait":
                    orders = GetOrders().Where(o => o.Status == 0);
                    break;
                case "ship":
                    orders = GetOrders().Where(o => o.Status == 1);
                    break;
                case "done":
                    orders = GetOrders().Where(o => o.Status == 2);
                    break;
                case "cancel":
                    orders = GetOrders().Where(o => o.Status == -1);
                    break;
                default:
                    break;
            }
            return orders;
        }
        public Order GetOrderById(string ID_Order)
        {
            return db.Orders.FirstOrDefault(o => o.ID_Order == ID_Order);
        }
        public IEnumerable<OrderDetail> GetOrderDetails(string ID_Order)
        {
            return db.OrderDetails.Where(o => o.ID_Order == ID_Order);
        }
        public OrderDetail GetOrderDetailByID(string ID_OrderDetail)
        {
            return db.OrderDetails.FirstOrDefault(o => o.ID_OrderDetail == ID_OrderDetail);
        }
        public Shipping GetShippingByID(string ID_Order)
        {
            var Name = GetOrderById(ID_Order).ShippingMethod;
            return db.Shippings.FirstOrDefault(s => s.Name == Name);
        }

        public int GetReLoadOrders()
        {
            return db.ReloadOrders();
        }
        
        public bool ConfirmOrder(string ID_Order)
        {
            try
            {
                var query = "update Orders set Status = 1 where ID_Order = '" + ID_Order + "'";
                db.Database.ExecuteSqlCommand(query);
                db.spUpdateQuantityAfterOrder(ID_Order);
                return true;
            }catch(Exception) { return false; }
        }
        public bool CancelOrder(string ID_Order)
        {
            try
            {
                var query = "update Orders set Status = -1 where ID_Order = '" + ID_Order + "'";
                db.Database.ExecuteSqlCommand(query);
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}