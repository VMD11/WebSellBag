using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.Model
{
    public class PaymentMethod
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }

        public PaymentMethod(string name, string imageURL)
        {
            Name = name;
            ImageURL = imageURL;
        }
    }
}