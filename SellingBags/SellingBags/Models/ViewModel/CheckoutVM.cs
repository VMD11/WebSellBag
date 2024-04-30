using SellingBags.Models.DataContext;
using SellingBags.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.ViewModel
{
    public class CheckoutVM
    {
        public VirtualCartContext Cart { get; set; }
        public IEnumerable<Address> Addresses { get; set; }

        public IEnumerable<Shipping> Shippings { get; set; }
        
        public IEnumerable<Payment> Payments { get; set; }
    }
}