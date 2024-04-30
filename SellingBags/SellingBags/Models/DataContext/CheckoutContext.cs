using SellingBags.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.DataContext
{
    public class CheckoutContext
    {
        private SellingBagsEntities db = null;
        private OrderContext orderContext = new OrderContext();
        public CheckoutContext()
        {
            db = new SellingBagsEntities();
        }
        

        public IEnumerable<Payment> GetPayments()
        {
            return db.Payments;
        }
        public IEnumerable<Shipping> GetShippings() 
        {
            return db.Shippings;
        }
        
        public IEnumerable<Address> GetAddresses(string ID_Account)
        {
            
            var ID_Customer = orderContext.GetCustomer(ID_Account).ID_Customer;
            return db.Addresses.Where(a => a.ID_Customer == ID_Customer);

        }
    }
}