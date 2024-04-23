using SellingBags.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SellingBags.Areas.Admin.Models.DataContext
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
            var account = db.Accounts.FirstOrDefault(a => a.UserName == username);
            if (account == null)
            {
                return 0;
            }
            else
            {
                Debug.WriteLine(account.Password);
                Debug.WriteLine(password);
                var check = account.Password.Trim() == password;
                Debug.WriteLine(check);
                if(account.Password.Trim() == password)
                {
                    if(account.ID_Role.Trim() == "R01")
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -2;
                }
            }
        }
    }
}