using SellingBags.Models.DataContext;
using SellingBags.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.ViewModel
{
    public class OrderVM
    {
        public string ID_Order { get; set; }
        public string ID_Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string SpecificAddress { get; set; }
        public string PaymentName { get; set; }
        public string ShippingName { get; set; }
        public decimal TotalMoney { get; set; }
        public VirtualCartContext Cart { get; set; }
        public Address Address { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
        public Shipping Shipping { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}