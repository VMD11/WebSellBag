using SellingBags.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Areas.Admin.Models.ViewModel
{
    public class OrderVM
    {
        public Address Address { get; set; }
        public Order Order { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public Shipping Shipping { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}