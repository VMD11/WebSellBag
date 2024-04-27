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
        public int DeliDate { get; set; }
        public decimal Cost { get; set; }

        public ShippingMethod(string name, string delitime, int delidate, decimal cost)
        {
            Name = name;
            DeliTime = delitime;
            DeliDate = delidate;
            Cost = cost;
        }
    }
}