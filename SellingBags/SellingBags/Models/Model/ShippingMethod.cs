using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.Model
{
    public class ShippingMethod
    {
        public string Name { get; set; }
        public string DeliTime { get; set; }
        public decimal Cost { get; set; }

        public ShippingMethod(string name, string delitime, decimal cost)
        {
            Name = name;
            DeliTime = delitime;
            Cost = cost;
        }
    }
}