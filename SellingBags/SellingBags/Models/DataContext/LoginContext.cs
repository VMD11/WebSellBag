using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.DataContext
{
    public class LoginContext
    {
        SellingBagsEntities db = null;
        public LoginContext() 
        {
            db = new SellingBagsEntities();
        }

        public Account GetByName(string username)
        {
            return db.Accounts.FirstOrDefault(a => a.UserName == username);
        }

        public int Login(string username, string password)
        {
            var result = db.Accounts.FirstOrDefault(a => a.UserName == username && a.Password == password);
            if(result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}