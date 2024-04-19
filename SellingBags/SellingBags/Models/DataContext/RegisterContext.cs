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
            string ID_Customer = "C0";
            string lastCustomer = db.spLastCustomer().Last().Trim();
            List<string> test = db.spLastCustomer().ToList();

            Debug.WriteLine(lastCustomer);
            foreach(string s in test)
            {
                Debug.WriteLine(s);
            }
            if(string.IsNullOrEmpty(lastCustomer))
            {
                ID_Customer += 1.ToString();
            }
            else
            {
                int number = int.Parse(lastCustomer.Substring(2));
                number++;
                ID_Customer += number.ToString();
                
            }

            Account account = new Account { ID_Account = GenarateRandomID.Execute(), UserName = registerVM.UserName, Password = Encryptor.MD5Hash(registerVM.Password), ID_Role = "R02" };
            db.Accounts.Add(account);

            Customer customer = null;
            if(registerVM.UserName.Contains("@"))
            {
                customer = new Customer
                {
                    ID_Customer = ID_Customer,
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    Email = registerVM.UserName,
                    PhoneNumber = null,
                    Address = null,
                    City = null,
                    Country = null,
                    ID_Account = account.ID_Account
                };
            }
            else
            {
                customer = new Customer
                {
                    ID_Customer = ID_Customer,
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    Email = null,
                    PhoneNumber = registerVM.UserName,
                    Address = null,
                    City = null,
                    Country = null,
                    ID_Account = account.ID_Account,
                    
                };
            }

            db.Customers.Add(customer);
            db.SaveChanges();
        }

    }
}