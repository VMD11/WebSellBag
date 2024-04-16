using SellingBags.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingBags.Models.ViewModel
{
    public class CartVM
    {
        public string ID_Account { get; set; }
        public Cart cart { get; set; }
    }
}