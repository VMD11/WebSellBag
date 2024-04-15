using SellingBags.Converter;
using SellingBags.Models.ViewModel;
using System;
using System.Collections.Generic;
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

        public static string GenerateRandomID()
        {
            int byteLength = 5; // Số lượng byte cần sinh ra (tương đương với 10 ký tự hex)
            byte[] randomBytes = new byte[byteLength];

            // Sinh byte ngẫu nhiên
            new Random().NextBytes(randomBytes);

            // Chuyển đổi sang chuỗi hex
            string randomHex = BitConverter.ToString(randomBytes).Replace("-", "");

            return randomHex;
        }

        public void Register(RegisterVM registerVM)
        {
            string ID_Customer = "C0";
            string lastCustomer = db.spLastCustomer().ToString().Trim();
            if(lastCustomer == null)
            {
                ID_Customer += 1.ToString();
            }
            else
            {
                int number = int.Parse(lastCustomer.Substring(2));
                number++;
                ID_Customer += number.ToString();
            }

            Account account = new Account { ID_Account = GenerateRandomID(), UserName = registerVM.UserName, Password = Encryptor.MD5Hash(registerVM.Password), ID_Role = "R02" };
            db.Accounts.Add(account);

            Customer customer = null;
            if(registerVM.UserName.Contains("@"))
            {
                customer = new Customer { ID_Customer = ID_Customer, FirstName = registerVM.FirstName, LastName = registerVM.LastName, Email = registerVM.UserName, ID_Account = account.ID_Account };
            }
            else
            {
                customer = new Customer { ID_Customer = ID_Customer, FirstName = registerVM.FirstName, LastName = registerVM.LastName, PhoneNumber = registerVM.UserName, ID_Account = account.ID_Account };
            }
            db.Customers.Add(customer);

            db.SaveChanges();
        }

    }
}