using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.DataContext
{
    public class AccountContext
    {
        private static SellingBagsEntities db = new SellingBagsEntities();
        public static Account GetAccountByID(string ID_Account)
        {
            return db.Accounts.FirstOrDefault(a => a.ID_Account == ID_Account);
        }

        public static Customer GetCustomerByID(string ID_Account)
        {
            return db.Customers.FirstOrDefault(c => c.ID_Account == ID_Account);
        }

        public static IEnumerable<Address> GetAddressesByID(string ID_Account)
        {
            var ID_Customer = GetCustomerByID(ID_Account).ID_Customer;
            return db.Addresses.Where(a => a.ID_Customer == ID_Customer);
        }
    }
}