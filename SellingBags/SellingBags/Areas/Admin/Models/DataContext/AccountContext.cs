using SellingBags.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Areas.Admin.Models.DataContext
{
    public class AccountContext
    {
        private static SellingBagsEntities db = new SellingBagsEntities();

        public static IEnumerable<Account> GetAccounts()
        {
            return db.Accounts.Where(a => a.ID_Role == "R02");
        }
        public static IEnumerable<Customer> GetCustomers()
        {
            return db.Customers;
        }

        public static Customer GetCustomer(string ID_Account)
        {
            return db.Customers.FirstOrDefault(c => c.ID_Account == ID_Account);
        }

        public static Account GetAccount(string ID_Account)
        {
            return db.Accounts.FirstOrDefault(a => a.ID_Account == ID_Account);
        }

        public static bool LockAccount(string ID_Account)
        {
            try
            {
                var query = "update Account set Status = 0 where ID_Account = '" + ID_Account + "'";
                db.Database.ExecuteSqlCommand(query);
                return true;
            }catch(Exception) { return false; }
        }
        public static bool UnLockAccount(string ID_Account)
        {
            try
            {
                var query = "update Account set Status = 1 where ID_Account = '" + ID_Account + "'";
                db.Database.ExecuteSqlCommand(query);
                return true;
            }catch(Exception) { return false; }
        }

    }
}