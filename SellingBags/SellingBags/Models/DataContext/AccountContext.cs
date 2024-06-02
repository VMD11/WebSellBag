using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SellingBags.Models.DataContext
{
    public class AccountContext
    {
        private SellingBagsEntities db;
        public AccountContext()
        {
            db = new SellingBagsEntities();
        }
        public  Account GetAccountByID(string ID_Account)
        {
            return db.Accounts.FirstOrDefault(a => a.ID_Account == ID_Account);
        }

        public  Customer GetCustomerByID(string ID_Account)
        {
            return db.Customers.FirstOrDefault(c => c.ID_Account == ID_Account);
        }

        public  bool UpdateInfo(Customer newCustomer)
        {
            try
            {
                var customer = db.Customers.FirstOrDefault(c => c.ID_Customer == newCustomer.ID_Customer);
                if (customer == null) return false;
                customer.LastName = newCustomer.LastName;
                customer.FirstName = newCustomer.FirstName;
                customer.City = newCustomer.City;
                customer.District = newCustomer.District;
                customer.Ward = newCustomer.Ward;
                customer.Address = newCustomer.Address;
                customer.BirthDay = newCustomer.BirthDay.HasValue ? DateTime.ParseExact(newCustomer.BirthDay.Value.ToString("dd-MM-yyyy"),"yyyy-MM-dd",CultureInfo.InvariantCulture) : DateTime.Now;
                customer.Gender = newCustomer.Gender;
                db.SaveChanges();
                return true;
            }catch(Exception) { return false; }
        }

        public  IEnumerable<Address> GetAddressesByID(string ID_Account)
        {
            var ID_Customer = GetCustomerByID(ID_Account).ID_Customer;
            return db.Addresses.Where(a => a.ID_Customer == ID_Customer);
        }
<<<<<<< HEAD
        public  Address GetAddressByID(string ID_Address)
=======
        public static Address GetAddressByID(string ID_Address)
>>>>>>> f6f221431dafb1528938c0a5812fa6d099abbec0
        {
            return db.Addresses.FirstOrDefault(a => a.ID_Address == ID_Address);
        }

<<<<<<< HEAD
        public  bool AddAddress(Address address)
=======
        public static bool AddAddress(Address address)
>>>>>>> f6f221431dafb1528938c0a5812fa6d099abbec0
        {
            try
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return true;
            }catch (Exception) { return false; }
        }
<<<<<<< HEAD

        public  bool UpdateAddress(Address address)
=======
        public static bool UpdateAddress(Address address)
>>>>>>> f6f221431dafb1528938c0a5812fa6d099abbec0
        {
            try
            {
                var oldAddress = GetAddressByID(address.ID_Address);
                if (oldAddress == null) return false;
                oldAddress.FirstName = address.FirstName;
                oldAddress.LastName = address.LastName;
                oldAddress.PhoneNumber = address.PhoneNumber;
                oldAddress.City = address.City;
                oldAddress.District = address.District;
                oldAddress.Ward = address.Ward;
                oldAddress.SpecificAddress = address.SpecificAddress;
                db.SaveChanges();
                return true;
            }catch (Exception) { return false; }
        }
<<<<<<< HEAD
        public  bool DeleteAddress(string ID_Address)
=======
        public static bool DeleteAddress(string ID_Address)
>>>>>>> f6f221431dafb1528938c0a5812fa6d099abbec0
        {
            try
            {
                var query = "delete Address where ID_Address = '" + ID_Address + "'";
                db.Database.ExecuteSqlCommand(query);
                return true;
            }catch (Exception) { return false; }
        }
    }
}