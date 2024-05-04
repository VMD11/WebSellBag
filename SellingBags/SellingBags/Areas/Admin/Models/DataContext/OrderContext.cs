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