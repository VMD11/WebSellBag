using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.ViewModel
{
    public class AccountVM
    {
        public Account Account { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}