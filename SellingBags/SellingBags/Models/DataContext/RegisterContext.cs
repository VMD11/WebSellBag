using SellingBags.Models.ViewModel;
using SellingBags.Converter;
using SellingBags.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SellingBags.Models.DataContext
{
    public class RegisterContext
    {
        SellingBagsEntities db = null;

        public RegisterContext()
        {
            db = new SellingBagsEntities();
        }

        public bool IsRegistered(string username)
        {
            Account account = db.Accounts.FirstOrDefault(a => a.UserName == username);
            if(account == null)
            {
                return false;
            }
            return true;
        }
        public void Register(RegisterVM registerVM)
        {
            Account account = new Account();
            account.ID_Account = GenarateRandomID.Execute();
            account.UserName = registerVM.UserName;
            account.Password = Encryptor.MD5Hash(registerVM.Password);
            account.ID_Role = "R02";
            db.Accounts.Add(account);

            Customer customer = null;
            if(registerVM.UserName.Contains("@"))
            {
                customer = new Customer
                {
                    ID_Customer = GenarateRandomID.Execute(),
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    Email = registerVM.UserName,
                    PhoneNumber = null,
                    ID_Account = account.ID_Account
                };
            }
            else
            {
                customer = new Customer
                {
                    ID_Customer = GenarateRandomID.Execute(),
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    Email = null,
                    PhoneNumber = registerVM.UserName,
                    ID_Account = account.ID_Account,
                    
                };
            }

            db.Customers.Add(customer);
            db.SaveChanges();
        }

    }
}