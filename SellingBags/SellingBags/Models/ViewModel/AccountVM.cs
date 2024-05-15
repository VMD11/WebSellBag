using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.ViewModel
{
    public class AccountVM
    {
        public string ID_Customer { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string SpecificAddress { get; set; }
        public DateTime BirthDay { get; set; }
        public string Gender { get; set; }
        public Account Account { get; set; }
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}