using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace SellingBags.Models.Model
{
    public class VirtualCart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double? Discount { get; set; }
    }
}