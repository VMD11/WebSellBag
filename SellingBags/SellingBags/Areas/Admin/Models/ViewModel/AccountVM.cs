using SellingBags.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Areas.Admin.Models.ViewModel
{
    public class AccountVM
    {
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<Customer> Customers{ get; set; }
    }
}