using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static bool UpdateInfo(Customer newCustomer)
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

        public static IEnumerable<Address> GetAddressesByID(string ID_Account)
        {
            var ID_Customer = GetCustomerByID(ID_Account).ID_Customer;
            return db.Addresses.Where(a => a.ID_Customer == ID_Customer);
        }
        public static Address GetAddressByID(string ID_Address)
        {
            return db.Addresses.FirstOrDefault(a => a.ID_Address == ID_Address);
        }

        public static bool AddAddress(Address address)
        {
            try
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return true;
            }catch (Exception) { return false; }
        }
        public static bool UpdateAddress(Address address)
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
        public static bool DeleteAddress(string ID_Address)
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